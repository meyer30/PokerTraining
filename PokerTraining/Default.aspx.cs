using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokerTraining
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                DealCards();
                BuildView();
            }
        }


        [WebMethod(EnableSession =true)]
        [ScriptMethod]
        public static string MyWebService2()
        {
            // code logic here

            

            if ((bool)HttpContext.Current.Session["userShouldCall"])
            {
                return "correct";
            }
            else
            {
                return "false";
            }
        }

        //[WebMethod(EnableSession =true)]
        //[ScriptMethod]
        //public static string MyWebService(String Data)
        //{
        //    // code logic here

        //    return "result";
        //}

        #region Event Handlers
        protected void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                switch (btn.ID)
                {
                    case "btnDeal":
                        DealCards();
                        break;
                    case "btnCall":
                        btnCall_Click();
                        break;
                    case "btnFold":
                        btnFold_Click();
                        break;
                    default:
                        break;
                }
                BuildView();
            }
        }

        protected void DealCards()
        {

            int numCommCards = int.Parse(this.ddlNumCommCards.SelectedValue);

            Pocket myCards = new Pocket();
            Community commCards = new Community(myCards.CardList, numCommCards);

            Random randNum = new Random();
            int potTotal = randNum.Next(1, 10);
            int currentBet = randNum.Next(1, potTotal);

            double oddsWinning = myCards.GetOddsWin(commCards);
            double potOdds = (double)currentBet / (double)potTotal;
            if (Math.Abs(oddsWinning - potOdds) > .15)
            {
                DealCards();
            }
            else
            {
                Session["userShouldCall"] = oddsWinning >= potOdds;
                Session["myCards"] = myCards;
                Session["commCards"] = commCards;
                Session["bet"] = currentBet;
                Session["potTotal"] = potTotal;
            }
        }

        private void BuildView()
        {
            int bet = (int)Session["bet"];
            int potTotal = (int)Session["potTotal"];
            Pocket p = (Pocket)Session["myCards"];
            Community c = (Community)Session["commCards"];
            TableRow tr = GetCardTabRow(p.CardList);
            this.TablePocket.Rows.Add(tr);
            tr = GetCardTabRow(c.CardList);
            while (tr.Cells.Count < 5)
            {
                tr.Cells.Add(GetCardTabCell(null));
            }
            this.TableCommunity.Rows.Add(tr);
            this.TablePotOdds.Rows.Add(GetPotTabRow(bet, potTotal));
        }


        protected void btnCall_Click()
        {
            if ((bool)Session["userShouldCall"])
            {
                UserRight();
            }
            else
            {
                UserWrong();
            }
        }

        protected void btnFold_Click()
        {
            if ((bool)Session["userShouldCall"])
            {
                UserWrong();
            }
            else
            {
                UserRight();
            }
        }

        protected void UserRight()
        {
            Display("Right");
        }

        protected void UserWrong()
        {
            //WrongAns wa = new WrongAns(Session["myCards"], Session["commCards"], Session["bet"], Session["pot"]);
            //List<WrongAns> waList = (List<WrongAns>)Session["WrongAnsList"];
            //waList.Add(wa);
            //Session["WrongAnsList"] = waList;
            Display("Wrong");
        }


        #endregion

        private void Display(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "alert('" + message + "');", true);
        }


        #region TableHelpers
        private TableRow GetPotTabRow(int bet, int potTotal)
        {
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            tc.Text = "$" + bet;
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "$" + potTotal;
            tr.Cells.Add(tc);
            return tr;
        }
        
        private TableRow GetCardTabRow(List<Card> list)
        {
            TableRow tr = new TableRow();
            foreach (Card c in list)
            {
                TableCell tc = GetCardTabCell(c);
                tr.Cells.Add(tc);
            }
            return tr;
        }


        private TableCell GetCardTabCell(Card card)
        {
            TableCell tc = new TableCell();
            Image img = new Image();
            img.ImageUrl = GetImgUrl(card);
            tc.Controls.Add(img);
            return tc;
        }

        private string GetImgUrl(Card card)
        {
            if(card==null)
            {
                return "Images\\b1fv.png";
            }
            int cardNum = (12 - (card.GetRank)) * 4;

            switch (card.GetSuit)
            {
                case Suit.clubs:
                    cardNum += 1;
                    break;
                case Suit.diamonds:
                    cardNum += 4;
                    break;
                case Suit.hearts:
                    cardNum += 3;
                    break;
                default:
                    cardNum += 2;
                    break;
            }

            return "Images\\" + cardNum + ".png";
        }
        #endregion
    };

};