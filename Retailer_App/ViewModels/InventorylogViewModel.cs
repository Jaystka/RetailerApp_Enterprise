using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using Retailer_App.Setup;
using Retailer_App.Models;
using Retailer_App.Views.Inventories;
using System.Threading.Tasks;

namespace Retailer_App.ViewModels
{
    public class InventorylogViewModel : INotifyPropertyChanged
    {
        public InventorylogViewModel()
        {
            collection = new ObservableCollection<Inventorylog>();
            dbconn = new Db_Connection();
            model = new Inventorylog();

            InsertCommand = new RelayCommand(async () => await InsertDataAsync());
            SelectCommand = new RelayCommand(async () => await ReadDataAsync());
            SelectCommand.Execute(null);
        }

        public RelayCommand InsertCommand { get; set; }
        public RelayCommand SelectCommand { get; set; }

        public ObservableCollection<Inventorylog> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(null));
            }
        }

        public Inventorylog Model
        {
            get
            {
                return model;
            }
            set
            {
               // if (value != null)
              //  {
              //      IsChecked = (value.Status == "Active") ? true : false;
              //  }
                model = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(null));
            }
        }


        public bool IsChecked
        {
            get
            {
                return check;
            }
            set
            {
                check = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(null));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action OnCallBack;

        private readonly Db_Connection dbconn;
        private ObservableCollection<Inventorylog> collection;
        private Inventorylog model;
        private bool check;

        private async Task ReadDataAsync()
        {
            dbconn.OpenConnection();

            await Task.Delay(0);
            var query = "SELECT * FROM vproductstock";
            var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
            var sqlresult = sqlcmd.ExecuteReader();

            if (sqlresult.HasRows)
            {
                collection.Clear();
                while (sqlresult.Read())
                {
                    collection.Add(new Inventorylog
                    {
                        Uid = Convert.ToInt32(sqlresult[0]),
                        Products = 
                        {
                            Name = sqlresult[1].ToString()
                        },
                        Qty = Convert.ToInt32(sqlresult[2]),
                    });
                }
            }
            dbconn.CloseConnection();
            OnCallBack?.Invoke();
        }

        private async Task InsertDataAsync()
        {
            if (IsValidating())
            {
                dbconn.OpenConnection();
               // var state = check ? "1" : "0";
                var query = $"DECLARE @new_uid TABLE (uid INT) " +
                            $"INSERT INTO inventories(id_user, logdate, type, description, status, expdate) " +
                            $"OUTPUT inserted.uid INTO @new_uid " +
                            $"VALUES ({App.SessionUid}, (SELECT CONVERT (VARCHAR(10),GETDATE(),111)), " +
                            $"'{StockDialog.InsertType}', '{StockDialog.InsertDesc}', 1, '{StockDialog.ExpDate}') " +
                            $"INSERT INTO inventorylogs(id_inventory, id_product, qty) " +
                            $"VALUES ((SELECT uid FROM @new_uid), {Model.Uid}, {StockDialog.InsertQty})";
                var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
                sqlcmd.ExecuteNonQuery();
                dbconn.CloseConnection();
                await ReadDataAsync();
            }
        }


        private bool IsValidating()
        {
            var flag = true;
            if (model.Uid == 0)
            {
                MessageBox.Show("Teks 1 tidak boleh kosong!!", "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
                flag = false;
            }
            else if (StockDialog.ExpDate == null)
            {
                MessageBox.Show("Teks 2 tidak boleh kosong!!", "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
                flag = false;
            }
            else if (StockDialog.InsertQty == 0)
            {
                MessageBox.Show("Teks 3 tidak boleh kosong!!", "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
                flag = false;
            }
            else if (StockDialog.InsertType == null)
            {
                MessageBox.Show("Teks 4 tidak boleh kosong!!", "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
                flag = false;
            }
            return flag;
        }
    }
}
