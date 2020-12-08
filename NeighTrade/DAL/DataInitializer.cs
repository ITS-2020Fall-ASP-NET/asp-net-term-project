using NeighTrade.Models;
using System.Collections.Generic;

namespace NeighTrade.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<NeighTradeContext>
    {
        protected override void Seed(NeighTradeContext context) {
            // address
            var addresses = new List<Address>
            {
            new Address {
                Address1="2132 Meadowglen Dr",
                Address2="",
                Address3="",
                City="Oakville",
                State=State.ON,
                Country="CA",
                PostalCode="L6M3C4"
            },
            new Address {
                Address1="2132 Rainbow Pl.",
                Address2="",
                Address3="",
                City="Vaughan",
                State=State.ON,
                Country="CA",
                PostalCode="L1M2C3"
            }
            };
            addresses.ForEach(a => context.Addresses.Add(a));
            context.SaveChanges();

            // user
            var users = new List<User>
            {
            new User {
                Email="hansol.jo@gmail.com",
                Password="12341234",
                Fname="Hansol",
                Lname="Jo",
                Reputation=0,
                AddressId=1
            },
            new User {
                Email="sarachen0712@gmail.com",
                Password="12341234",
                Fname="Sara",
                Lname="Chen",
                Reputation=0,
                AddressId=2
            }
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            // item
            var items = new List<Item>
            {
            new Item {
                Name="Intel i7-10700k",
                Category=Category.ConsumerElectronics,
                ListingPrice=500,
                Description="Bang for bucks",
                UserId=1,
                LikeCount=123,
                ImgPath="71P3chRzgNL._AC_UL270_SR234,270_.jpg"
            },
            new Item {
                Name="Samsung EVO 970 Plus",
                Category=Category.ConsumerElectronics,
                ListingPrice=200,
                Description="Best ssd ever",
                UserId=1,
                LikeCount=12,
                ImgPath="31_rkXdQL8L._AC_SY200_.jpg"
            }
            };
            items.ForEach(i => context.Items.Add(i));
            context.SaveChanges();
        }
    }
}