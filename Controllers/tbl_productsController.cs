using Productwebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Productwebsite.Controllers
{
    public class tbl_productsController : Controller
    {
        String constr = "Data Source=DESKTOP-HHT2L8N\\SQLEXPRESS;Initial catalog= mvc1; Integrated Security=True";
        // GET: tbl_products
        public ActionResult Index()
        {
            List<tbl_products> tbl_Products_obj = new List<tbl_products>();
            SqlConnection con = new SqlConnection (constr);
            SqlCommand cmd = new SqlCommand("get_products", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                tbl_Products_obj.Add(new tbl_products
                {
                    id = Convert.ToInt32(sdr["id"]),
                    product_name = Convert.ToString(sdr["product_name"]),
                    quantity = Convert.ToInt32(sdr["quantity"])
                }
                    );
            }
            con.Close();
            
            return View(tbl_Products_obj);
        }

        // GET: tbl_products/Details/5
        public ActionResult Details(int id, tbl_products tbl_products_obj)
        {

            SqlConnection con = new SqlConnection(constr);
            String query = "get_products_id " + id;
            SqlCommand cmd = new SqlCommand(query, con);
           
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                tbl_products_obj = new tbl_products
                {
                    id = Convert.ToInt32(sdr["id"]),
                    product_name = Convert.ToString(sdr["product_name"]),
                    quantity = Convert.ToInt32(sdr["quantity"])
                };

            }
            con.Close();
            return View(tbl_products_obj);
        }

        // GET: tbl_products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_products/Create
        [HttpPost]
        public ActionResult Create(tbl_products tbl_productsobj)
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                String Query = "insert_products '" + tbl_productsobj.product_name + " '," + tbl_productsobj.quantity;

                SqlCommand cmd = new SqlCommand("query", con);
               
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: tbl_products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: tbl_products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tbl_products tbl_productsobj)
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                String Query = "edit_products " + id+ ",'" + tbl_productsobj.product_name + " '," + tbl_productsobj.quantity;

                SqlCommand cmd = new SqlCommand("query", con);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: tbl_products/Delete/5
        public ActionResult Delete(int id, tbl_products tbl_products_obj)
        {
            SqlConnection con = new SqlConnection(constr);
            String query = "get_products_id " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                tbl_products_obj = new tbl_products
                {
                    id = Convert.ToInt32(sdr["id"]),
                    product_name = Convert.ToString(sdr["product_name"]),
                    quantity = Convert.ToInt32(sdr["quantity"])
                };
                
            }
            con.Close();
            return View(tbl_products_obj);
        }

        // POST: tbl_products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {

                SqlConnection con = new SqlConnection(constr);
                String Query = "delete_products " + id ;

                SqlCommand cmd = new SqlCommand("Query", con);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
