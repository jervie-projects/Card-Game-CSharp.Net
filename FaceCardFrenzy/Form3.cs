using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FaceCardFrenzy
{
    public partial class Form3 : Form
    {
        List<Cards> cards = new List<Cards>();
        Random random = new Random();
        List<String> WinningCards = new List<String>
        {
        "Ace_Club", "Ace_Spade", "Ace_Heart", "Ace_Dias", "Jack_Club","Jack_Spade","Jack_Heart","Jack_Dias",
        "Queen_Club","Queen_Spade","Queen_Heart","Queen_Dias","King_Club","King_Spade","King_Heart","King_Dias"

        };
        bool P1Turn = true;
        bool P2Turn = false;
        List<Cards> P1Cards = new List<Cards>();
        List<Cards> P2Cards = new List<Cards>();
        List<int> P1CardId = new List<int>();
        List<int> P2CardId = new List<int>();
        List<Cards> DiscardedCards = new List<Cards>();

        public Form3()
        {
            InitializeComponent();
            Card_Populate();

        }
        private void Card_Populate()
        {
            cards.Add(new Cards(Properties.Resources.Ace_Club, "Ace_Club", 1));
            cards.Add(new Cards(Properties.Resources._2_Club, "_2_Club", 2));
            cards.Add(new Cards(Properties.Resources._3_Club, "_3_Club", 3));
            cards.Add(new Cards(Properties.Resources._4_Club, "_4_Club", 4));
            cards.Add(new Cards(Properties.Resources._5_Club, "_5_Club", 5));
            cards.Add(new Cards(Properties.Resources._6_Club, "_6_Club", 6));
            cards.Add(new Cards(Properties.Resources._7_Club, "_7_Club", 7));
            cards.Add(new Cards(Properties.Resources._8_Club, "_8_Club", 8));
            cards.Add(new Cards(Properties.Resources._9_Club, "_9_Club", 9));
            cards.Add(new Cards(Properties.Resources._10_Club, "_10_Club", 10));
            cards.Add(new Cards(Properties.Resources.Jack_Club, "Jack_Club", 11));
            cards.Add(new Cards(Properties.Resources.Queen_Club, "Queen_Club", 12));
            cards.Add(new Cards(Properties.Resources.King_Club, "King_Club", 13));

            cards.Add(new Cards(Properties.Resources.Ace_Heart, "Ace_Heart", 1));
            cards.Add(new Cards(Properties.Resources._2_Heart, "_2_Heart", 2));
            cards.Add(new Cards(Properties.Resources._3_Heart, "_3_Heart", 3));
            cards.Add(new Cards(Properties.Resources._4_Heart, "_4_Heart", 4));
            cards.Add(new Cards(Properties.Resources._5_Heart, "_5_Heart", 5));
            cards.Add(new Cards(Properties.Resources._6_Heart, "_6_Heart", 6));
            cards.Add(new Cards(Properties.Resources._7_Heart, "_7_Heart", 7));
            cards.Add(new Cards(Properties.Resources._8_Heart, "_8_Heart", 8));
            cards.Add(new Cards(Properties.Resources._9_Heart, "_9_Heart", 9));
            cards.Add(new Cards(Properties.Resources._10_Heart, "_10_Heart", 10));
            cards.Add(new Cards(Properties.Resources.Jack_Heart, "Jack_Heart", 11));
            cards.Add(new Cards(Properties.Resources.Queen_Heart, "Queen_Heart", 12));
            cards.Add(new Cards(Properties.Resources.King_Heart, "King_Heart", 13));

            cards.Add(new Cards(Properties.Resources.Ace_Spade, "Ace_Spade", 1));
            cards.Add(new Cards(Properties.Resources._2_Spade, "_2_Spade", 2));
            cards.Add(new Cards(Properties.Resources._3_Spade, "_3_Spade", 3));
            cards.Add(new Cards(Properties.Resources._4_Spade, "_4_Spade", 4));
            cards.Add(new Cards(Properties.Resources._5_Spade, "_5_Spade", 5));
            cards.Add(new Cards(Properties.Resources._6_Spade, "_6_Spade", 6));
            cards.Add(new Cards(Properties.Resources._7_spade, "_7_spade", 7));
            cards.Add(new Cards(Properties.Resources._8_Spade, "_8_Spade", 8));
            cards.Add(new Cards(Properties.Resources._9_Spade, "_9_Spade", 9));
            cards.Add(new Cards(Properties.Resources._10_Spade, "_10_Spade", 10));
            cards.Add(new Cards(Properties.Resources.Jack_Spade, "Jack_Spade", 11));
            cards.Add(new Cards(Properties.Resources.Queen_Spade, "Queen_Spade", 12));
            cards.Add(new Cards(Properties.Resources.King_Spade, "King_Spade", 13));

            cards.Add(new Cards(Properties.Resources.Ace_Dias, "Ace_Dias", 1));            
            cards.Add(new Cards(Properties.Resources._2_Dias, "_2_Dias", 2));
            cards.Add(new Cards(Properties.Resources._3_Dias, "_3_Dias", 3));
            cards.Add(new Cards(Properties.Resources._4_Dias, "_4_Dias", 4));
            cards.Add(new Cards(Properties.Resources._5_Dias, "_5_Dias", 5));
            cards.Add(new Cards(Properties.Resources._6_Dias, "_6_Dias", 6));
            cards.Add(new Cards(Properties.Resources._7_Dias, "_7_Dias", 7));
            cards.Add(new Cards(Properties.Resources._8_Dias, "_8_Dias", 8));
            cards.Add(new Cards(Properties.Resources._9_Dias, "_9_Dias", 9));
            cards.Add(new Cards(Properties.Resources._10_Dias, "_10_Dias", 10));
            cards.Add(new Cards(Properties.Resources.Jack_Dias, "Jack_Dias", 11));
            cards.Add(new Cards(Properties.Resources.Queen_Dias, "Queen_Dias", 12));
            cards.Add(new Cards(Properties.Resources.King_Dias, "King_Dias", 13));
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Draw_Deck.Image = Properties.Resources._1_Back;
        }

        public class Cards
        {
            public Image Image { get; set; }
            public String CardName { get; set; }
            public int Id { get; set; }
            public Cards(Image Img, string cardName, int id)
            {
                Image = Img;
                CardName = cardName;
                Id = id;
            }
        }


        private void Draw_Card(object sender, EventArgs e)
        {
            int rndIndex;
            Cards clickedCard;

            if (cards.Count > 0)
            {
                rndIndex = random.Next(0, cards.Count);
                clickedCard = cards[rndIndex];

                if (P1Turn)
                {
                    P1click(sender, e, clickedCard, rndIndex, clickedCard);
                    P1Turn = false;
                    P2Turn = true;
                    NotifLbl.Text = "Player 2";
                }
                else if (P2Turn)
                {
                    P2click(sender, e, clickedCard, rndIndex, clickedCard);
                    P2Turn = false;
                    P1Turn = true;
                    NotifLbl.Text = "Player 1";
                }

                Winner(); 

                bool noFaceCardsLeft = true;
                foreach (var card in cards)
                {
                    if (WinningCards.Contains(card.CardName))
                    {
                        noFaceCardsLeft = false;
                        break;
                    }
                }

                if (noFaceCardsLeft && !P1CardId.Contains(1) && !P2CardId.Contains(1))
                {
                    MessageBox.Show("No winner! Reshuffling Deck...");
                    Reset();
                }
            }
            else
            {
                ShuffleDeck();
            }
        }
        private void ShuffleDeck()
        {
            cards = DiscardedCards;
        }


        private void P1click(object sender, EventArgs e, Cards clickedCard, int rndIndex, Cards ClickedCard)
        {
            if (p1Deck1.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck1.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }


            }
            else if (p1Deck2.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck2.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }

            }
            else if (p1Deck3.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck3.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }

            }
            else if (p1Deck4.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck4.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p1Deck5.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck5.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p1Deck6.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck6.Image = clickedCard.Image;
                    Cards Player1Cards = ClickedCard;
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p1Deck7.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck7.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p1Deck8.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck8.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p1Deck9.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck9.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p1Deck10.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck10.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p1Deck11.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck11.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p1Deck12.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck12.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p1Deck13.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck13.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p1Deck14.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck14.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p1Deck15.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck15.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p1Deck16.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p1Deck16.Image = clickedCard.Image;
                    P1Cards.Add(ClickedCard);
                    P1CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }

        }
        private void P2click(object sender, EventArgs e, Cards clickedCard, int rndIndex, Cards ClickedCard)
        {
            if (p2Deck1.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck1.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }


            }
            else if (p2Deck2.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck2.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }

            }
            else if (p2Deck3.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck3.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }

            }
            else if (p2Deck4.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck4.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p2Deck5.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck5.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p2Deck6.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck6.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p2Deck7.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck7.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p2Deck8.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck8.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p2Deck9.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck9.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p2Deck10.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck10.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p2Deck11.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck11.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p2Deck12.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck12.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p2Deck13.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck13.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p2Deck14.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck14.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p2Deck15.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck15.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
            else if (p2Deck16.Image == null)
            {
                if (WinningCards.Contains(clickedCard.CardName))
                {
                    p2Deck16.Image = clickedCard.Image;
                    P2Cards.Add(ClickedCard);
                    P2CardId.Add(cards[rndIndex].Id);
                    cards.RemoveAt(rndIndex);
                }
                else
                {
                    Discard_Pile.Image = clickedCard.Image;
                    DiscardedCards.Add(cards[rndIndex]);
                    cards.RemoveAt(rndIndex);
                }
            }
        }
        private void Winner()
        {
            bool p1Win = true;
            bool p2Win = true;

            foreach (int cardId in new List<int> { 1, 11, 12, 13 })
            {
                if (!P1CardId.Contains(cardId))
                {
                    p1Win = false;
                    break;
                }
            }

            foreach (int cardId in new List<int> { 1, 11, 12, 13 })
            {
                if (!P2CardId.Contains(cardId))
                {
                    p2Win = false;
                    break;
                }
            }

            if (p1Win)
            {
                MessageBox.Show("Player 1 wins");
                Reset();
            }
            else if (p2Win)
            {
                MessageBox.Show("Player 2 wins");
                Reset();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            P1Cards.Clear();
            P2Cards.Clear();
            P1CardId.Clear();
            P2CardId.Clear();
            cards.Clear();
            Card_Populate();


            p1Deck1.Image = null;
            p1Deck2.Image = null;
            p1Deck3.Image = null;
            p1Deck4.Image = null;
            p1Deck5.Image = null;
            p1Deck6.Image = null;
            p1Deck7.Image = null;
            p1Deck8.Image = null;
            p1Deck9.Image = null;
            p1Deck10.Image = null;
            p1Deck11.Image = null;
            p1Deck12.Image = null;
            p1Deck13.Image = null;
            p1Deck14.Image = null;
            p1Deck15.Image = null;
            p1Deck16.Image = null;

            p2Deck1.Image = null;
            p2Deck2.Image = null;
            p2Deck3.Image = null;
            p2Deck4.Image = null;
            p2Deck5.Image = null;
            p2Deck6.Image = null;
            p2Deck7.Image = null;
            p2Deck8.Image = null;
            p2Deck9.Image = null;
            p2Deck10.Image = null;
            p2Deck11.Image = null;
            p2Deck12.Image = null;
            p2Deck13.Image = null;
            p2Deck14.Image = null;
            p2Deck15.Image = null;
            p2Deck16.Image = null;

            Discard_Pile.Image = null;


            P1Turn = true;
            P2Turn = false;
            NotifLbl.Text = "Player 1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
