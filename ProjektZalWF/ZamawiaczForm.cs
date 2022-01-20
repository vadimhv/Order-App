using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektZalWF
{
    public partial class ZamawiaczForm : Form
    {
        public ZamawiaczForm()
        {
            InitializeComponent();
        }

        /* GLOBAL VARIABLES */
        readonly Repozytorium rep = new Repozytorium();
        List<Kanapka> kanapki;
        List<Napoj> napoji;
        List<Deser> desery;
        List<Dodatek> dodatki;
        Order order;
        readonly List<Order> orderList = new List<Order>();
        readonly List<Order> finishedOrderList = new List<Order>();
        double sandwitchRes = 0;
        double drinkRes = 0;
        double dessertRes = 0;
        double addonRes = 0;
        double result = 0;
        int orderNumber = 0;

        private void LoadData()
        {
            kanapki = rep.PobierzKanapki();
            napoji = rep.PobierzNapoj();
            desery = rep.PobierzDesery();
            dodatki = rep.PobierzDodatki();
        }
        private void WszytajDaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SandwitchListBox.Items.Count == 0 && DrinkListBox.Items.Count == 0 && DessertListBox.Items.Count == 0 && AddonsListBox.Items.Count == 0)
            {
                LoadData();
                var kanapkiName = from n in kanapki
                                  orderby n.Name descending
                                  select new { n.Name };
                foreach (var item in kanapkiName)
                {
                    SandwitchListBox.Items.Add(item.Name);
                }
                var napojiName = from n in napoji
                                 orderby n.Name descending
                                 select new { n.Name };
                foreach (var item in napojiName)
                {
                    DrinkListBox.Items.Add(item.Name);
                }
                var deseryName = from n in desery
                                 orderby n.Name descending
                                 select new { n.Name };
                foreach (var item in deseryName)
                {
                    DessertListBox.Items.Add(item.Name);
                }
                var dodatkiName = from n in dodatki
                                  orderby n.Name descending
                                  select new { n.Name };
                foreach (var item in dodatkiName)
                {
                    AddonsListBox.Items.Add(item.Name);
                }
            } else
            {
                MessageBox.Show("Dane już były wczytane", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SandwitchListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem;
            if (SandwitchListBox.SelectedIndex != -1)
            {
                sandwitchRes = 0;
                curItem = SandwitchListBox.SelectedItem.ToString();
                sandwitch_value.Text = curItem;
                var sandwitchData = kanapki.Where(n => n.Name == curItem).ToList();
                sandwitch_weight.Text = sandwitchData[0].Weight.ToString();
                if (sandwitchData[0].Vege == 1)
                {
                    sandwich_isVege.Text = "VEGE";
                }
                else
                {
                    sandwich_isVege.Text = "";
                }
                sandwitchRes = double.Parse(sandwitchData[0].Price.Replace(".", ","));
                CalcResult();
            }
        }
        private void DrinkListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem;
            if (DrinkListBox.SelectedIndex != -1)
            {
                drinkRes = 0;
                curItem = DrinkListBox.SelectedItem.ToString();
                drink_value.Text = curItem;
                var drinkData = napoji.Where(n => n.Name == curItem).ToList();
                drink_volume.Text = drinkData[0].Size.ToString();
                if (drinkData[0].Sugar == 0)
                {
                    drink_isSugarFree.Text = "SUGAR FREE";
                }
                else
                {
                    drink_isSugarFree.Text = "";
                }
                drinkRes = double.Parse(drinkData[0].Price.Replace(".", ","));
                CalcResult();
            }
        }
        private void DessertListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem;
            if (DessertListBox.SelectedIndex != -1)
            {
                dessertRes = 0;
                curItem = DessertListBox.SelectedItem.ToString();
                dessert_value.Text = curItem;

                var dessertData = desery.Where(n => n.Name == curItem).ToList();

                dessert_weight.Text = dessertData[0].Weight.ToString();

                dessert_cal.Text = "Cal." + dessertData[0].Calories.ToString();
                dessertRes = double.Parse(dessertData[0].Price.Replace(".", ","));
                CalcResult();
            }
        }
        private void AddonsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem;
            if (AddonsListBox.SelectedIndex != -1)
            {
                addonRes = 0;
                curItem = AddonsListBox.SelectedItem.ToString();
                addons_value.Text = curItem;

                var addonData = dodatki.Where(n => n.Name == curItem).ToList();

                addons_weight.Text = addonData[0].Volume.ToString();

                if (addonData[0].Sauce == 1)
                {
                    addons_extraSauce.Text = "EXTRA SAUCE";
                }
                else
                {
                    addons_extraSauce.Text = "";
                }
                addonRes = double.Parse(addonData[0].Price.Replace(".", ","));
                CalcResult();
            }
        }
        private void CalcResult()
        {
            result = sandwitchRes + drinkRes + dessertRes + addonRes;
            summary_price.Text = result.ToString() + " zł";
        }
        private void ClearOrderFields()
        {
            sandwitch_weight.Text = "";
            sandwitch_value.Text = "";
            sandwich_isVege.Text = "";
            dessert_value.Text = "";
            dessert_weight.Text = "";
            dessert_cal.Text = "";
            addons_value.Text = "";
            addons_weight.Text = "";
            addons_extraSauce.Text = "";
            drink_value.Text = "";
            drink_volume.Text = "";
            drink_isSugarFree.Text = "";

            SandwitchListBox.ClearSelected();
            DrinkListBox.ClearSelected();
            DessertListBox.ClearSelected();
            AddonsListBox.ClearSelected();

            summary_price.Text = "0";
            result = 0;
            sandwitchRes = 0;
            drinkRes = 0;
            dessertRes = 0;
            addonRes = 0;


        }
        private void ClearListBox()
        {
            SandwitchListBox.Items.Clear();
            DrinkListBox.Items.Clear();
            DessertListBox.Items.Clear();
            AddonsListBox.Items.Clear();
        }
        private void ClearOrderFieldsBtn_Click(object sender, EventArgs e)
        {
            ClearOrderFields();   
        }
        private void DoOrderComplete(Order orderToComplete)
        {
            RemoveOrderFromList(orderList, orderToComplete, waitOrderListBox);

            finishedOrderList.Add(orderToComplete);
            finishedOrderListBox.Items.Add(orderToComplete.OrderNumber);
        }
        private void RemoveOrderFromList(List<Order> orderList, Order order, ListBox listBox, int indexToRemove = 0)
        {
            orderList.Remove(order);
            listBox.Items.RemoveAt(indexToRemove);
        }
        private void ShowInfoAboutCompleteOrder(Order completeOrder)
        {
            notifyIcon1.BalloonTipTitle = "Zamówienie #" + completeOrder.OrderNumber;
            notifyIcon1.BalloonTipText = $"{completeOrder.OrderTime}\nCena: {completeOrder.OrderPrice} zł \n" +
                $"{(completeOrder.Sandwitch.Name.Length != 0 ? completeOrder.Sandwitch.Name + ", " : null)}" +
                $"{(completeOrder.Drink.Name.Length != 0 ? completeOrder.Drink.Name + ", " : null)}" +
                $"{(completeOrder.Desert.Name.Length != 0 ? completeOrder.Desert.Name + ", " : null)}" +
                $"{(completeOrder.Addon.Name.Length != 0 ? completeOrder.Addon.Name : null)}";
            notifyIcon1.ShowBalloonTip(5000);
        }
        private void AddLogToManagerInfo(Order actualOrder)
        {
            managerScreen.Items.Add($"{actualOrder.OrderNumber} | {actualOrder.OrderTime} | {result} zł  | " +
                    $"{(actualOrder.Sandwitch.Name.Length != 0 ? actualOrder.Sandwitch.Name + ", " : null)}" +
                    $"{(actualOrder.Drink.Name.Length != 0 ? actualOrder.Drink.Name + ", " : null)}" +
                    $"{(actualOrder.Desert.Name.Length != 0 ? actualOrder.Desert.Name + ", " : null)}" +
                    $"{(actualOrder.Addon.Name.Length != 0 ? actualOrder.Addon.Name : null)}");
        }
        private void OrderBtn_Click(object sender, EventArgs e)
        {
            Kanapka sand = new Kanapka
            {
                Name = sandwitch_value.Text,
            };
            Napoj drink = new Napoj
            {
                Name = drink_value.Text,
            };
            Deser dessert = new Deser
            {
                Name = dessert_value.Text
            };
            Dodatek addon = new Dodatek
            {
                Name = addons_value.Text
            };
            order = new Order
            {
                OrderNumber = orderNumber,
                OrderTime = DateTime.Now.ToString("HH:mm:ss"),
                OrderPrice = result,
                Sandwitch = sand,
                Drink = drink,
                Desert = dessert,
                Addon = addon
            };

            if(order.OrderPrice > 0)
            {
                orderList.Add(order);

                var actualOrderListItem = orderList[orderList.Count - 1];

                AddLogToManagerInfo(actualOrderListItem);

                orderNumber++;

                waitOrderListBox.Items.Add(actualOrderListItem.OrderNumber);

                ClearOrderFields();

                waitTimer.Start();
            } else
            {
                MessageBox.Show("Nie wybrałeś elementu do zamówienia", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void WaitTimer_Tick(object sender, EventArgs e)
        {
            if (waitOrderListBox.Items.Count == 0)
            {
                waitTimer.Stop();
            } else
            {
                var firstOrderItemInList = orderList.First();
                DoOrderComplete(firstOrderItemInList);
                ShowInfoAboutCompleteOrder(firstOrderItemInList);
            }
        }
        private void TakeComplete_Click(object sender, EventArgs e)
        {
            if (finishedOrderList.Count != 0)
            {
                var firstFinishedOrderInList = finishedOrderList.First();
                RemoveOrderFromList(finishedOrderList, firstFinishedOrderInList, finishedOrderListBox);
            } else
            {
                MessageBox.Show("Aktualnie nie ma gotowych zamówień", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ResetujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            waitOrderListBox.Items.Clear();
            finishedOrderListBox.Items.Clear();
            managerScreen.Items.Clear();
            ClearOrderFields();
            ClearListBox();
            waitTimer.Stop();
        }
        private void ZapiszListęZamówieńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter writetext = new StreamWriter("OrderList.txt");
            foreach(var item in managerScreen.Items)
            {
               writetext.WriteLine(item.ToString());
            }
            writetext.Close();
        }
        private void OrderFinishedWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (finishedOrderListBox.SelectedIndex == -1)
                return;
            var item = finishedOrderListBox.SelectedIndex;
            finishedOrderListBox.Items.RemoveAt(item);
            finishedOrderList.RemoveAt(item);
        } 
    }
}
