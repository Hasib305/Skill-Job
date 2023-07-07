using Jobfinding.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobfinding.Data.Cart
{
    public class ApplyCart
    {
        public AppDbContext _context { get; set; }

        public string ApplyCartId { get; set; }
        public List<ApplyCartItem>ApplyCartItems { get; set; }

        public ApplyCart(AppDbContext context)
        {
            _context = context;
          
        }

        public static ApplyCart GetApplyCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ApplyCart( context) { ApplyCartId = cartId };
        }


        public void AddItemToCart(Findjobs findjobs)
        {
            var applyCartItem = _context.ApplyCartItems.FirstOrDefault(n => n.Findjobs.Id == findjobs.Id &&
            n.ApplyCartId == ApplyCartId);


            if(applyCartItem == null) {

                applyCartItem = new ApplyCartItem()
                {
                    ApplyCartId = ApplyCartId,
                    Findjobs = findjobs,
                    Amount = 1
                };

                _context.ApplyCartItems.Add(applyCartItem);           
            } else
            {
                applyCartItem.Amount++;
            }
            _context.SaveChanges();

        }

        public void RemoveItemFromCart(Findjobs findjobs)
        {
            var applyCartItem = _context.ApplyCartItems.FirstOrDefault(n => n.Findjobs.Id == findjobs.Id && n.ApplyCartId == ApplyCartId);

            if (applyCartItem != null)
            {
                if (applyCartItem.Amount > 1)
                {
                    applyCartItem.Amount--;
                }
                else
                {
                    _context.ApplyCartItems.Remove(applyCartItem);
                }
            }
            _context.SaveChanges();
        }


        public List<ApplyCartItem> GetApplyCartItems()
        {
            return ApplyCartItems ?? (ApplyCartItems = _context.ApplyCartItems.Where(n=>n.ApplyCartId== ApplyCartId).Include(n=>n.Findjobs).ToList());
        }
        public double GetApplyCartTotal() => _context.ApplyCartItems.Where(n=>n.ApplyCartId==ApplyCartId).Select(n=>n.Findjobs.Salary*n.Amount*10/100).Sum();
        
        public async Task ClearApplyCartAsync()
        {
            var items =await _context.ApplyCartItems.Where(n=>n.ApplyCartId==ApplyCartId).ToListAsync();
            _context.ApplyCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
