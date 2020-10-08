using AspNetTeam_Prj.Constants;
using AspNetTeam_Prj.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetTeam_Prj.Controllers
{
    public class ItemDetailController : Controller
    {
        // GET: ItemDetail
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int id, bool ShowAlreadyLikedModal)
        {
            ViewBag.ShowAlreadyLikedModal = ShowAlreadyLikedModal;
            string query = "SELECT * FROM item WHERE item_id=" + id;
            var conn = new SqlConnection(Conn.connString);
            var cmd = new SqlCommand(query, conn);
            conn.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                var item = new Item();
                while (rdr.Read())
                {
                    item.item_id = rdr.GetInt32(rdr.GetOrdinal("item_id"));
                    item.user_id = rdr.GetInt32(rdr.GetOrdinal("user_id"));
                    item.name = rdr.GetString(rdr.GetOrdinal("name"));
                    item.listing_price = rdr.GetDecimal(rdr.GetOrdinal("listing_price"));
                    item.description = rdr.GetString(rdr.GetOrdinal("description"));
                    item.category = rdr.GetInt32(rdr.GetOrdinal("category"));
                    item.like_count = rdr.GetString(rdr.GetOrdinal("like_count"));
                    break;
                }
                conn.Close();
                return View(item);
            }
            conn.Close();
            return View();

        }


        public ActionResult Like(int id, int user_id, string count)
        {
            var conn = new SqlConnection(Conn.connString);
            conn.Open();
            if (!IsAlreadyLiked(conn, user_id, id))
            {
                AddLikeCount(conn, count, id);
                InsertRowToLikeTable(conn, user_id, id);
                conn.Close();
                return RedirectToAction("Detail", new { id, ShowAlreadyLikedModal = false });
            }
            else
            {
                conn.Close();
                return RedirectToAction("Detail", new { id, ShowAlreadyLikedModal = true });
            }

        }
        private void AddLikeCount(SqlConnection conn, string count, int item_id)
        {
            int like_count = Int32.Parse(count) + 1;
            string query2 = "UPDATE item SET like_count=" + like_count.ToString() + "WHERE item_id=" + item_id;
            var cmd = new SqlCommand(query2, conn);
            cmd.ExecuteReader();
        }
        private int GetLikeRowCount(SqlConnection conn)
        {
            string query = "SELECT * FROM [LIKE]";
            var cmd = new SqlCommand(query, conn);
            var rdr = cmd.ExecuteReader();
            int count = 0;
            if (rdr.HasRows)
                while (rdr.Read())
                    count++;
            return count;
        }
        private bool IsAlreadyLiked(SqlConnection conn, int user_id, int item_id)
        {
            string query = "SELECT * FROM [like] WHERE user_id=@val1 and item_id=@val2";
            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@val1", user_id);
            cmd.Parameters.AddWithValue("@val2", item_id);
            var rdr = cmd.ExecuteReader();
            return rdr.HasRows;
        }
        private void InsertRowToLikeTable(SqlConnection conn, int user_id, int item_id)
        {
            int rowCount = GetLikeRowCount(conn);
            string query3 = "INSERT INTO [like] (like_id, user_id, item_id) VALUES (@val1, @val2, @val3)";
            var cmd = new SqlCommand(query3, conn);
            cmd.Parameters.AddWithValue("@val1", rowCount + 1);
            cmd.Parameters.AddWithValue("@val2", user_id);
            cmd.Parameters.AddWithValue("@val3", item_id);
            cmd.ExecuteReader();
        }
    }
}