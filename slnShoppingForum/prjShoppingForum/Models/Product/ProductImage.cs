using prjShoppingForum.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace prjShoppingForum.Models.Product
{
    public class ProductImage
    {
        dbShoppingForumEntities db = new dbShoppingForumEntities();

        public void GetImage(tProduct prod, HttpPostedFileBase prodImg,HttpServerUtilityBase server)
        {
            string fileName = "";
            if (prodImg != null)
            {
                if (prodImg.ContentLength > 0)
                {
                    fileName = prod.fProductID + Path.GetExtension(prodImg.FileName);
                    var path = Path.Combine(server.MapPath("~/Images/Product"), fileName);
                    prodImg.SaveAs(path);
                }
            }

            var product = db.tProducts.FirstOrDefault(p => p.fProductID == prod.fProductID);
            var unil = db.tProductUnilaterals.FirstOrDefault(p => p.fProductID == prod.fProductID);
            var vegetable = db.tProductVegetableoils.FirstOrDefault(p => p.fProductID == prod.fProductID);

            try
            {
                product.fProductChName = prod.fProductChName;
                product.fProductDesc = prod.fProductDesc;
                product.fUnitPrice = prod.fUnitPrice;
                product.fQuantityPerUnit = prod.fQuantityPerUnit;
                product.fCategoryID = prod.fCategoryID;
                if (vegetable != null)
                {
                    vegetable.tfeature = prod.tProductVegetableoil.tfeature;
                }
                
                if (unil != null)
                {
                    unil.fPartID = prod.tProductUnilateral.fPartID;
                    unil.fNoteID = prod.tProductUnilateral.fNoteID;
                    unil.fOrigin = prod.tProductUnilateral.fOrigin;
                    unil.fextraction = prod.tProductUnilateral.fextraction;
                }
                db.SaveChanges();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

    }
}