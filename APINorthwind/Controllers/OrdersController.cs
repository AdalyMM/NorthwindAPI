using APINorthwind.DTOs;
using APINorthwind.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

namespace APINorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly NorthwindContext _context;
        private readonly IMapper _mapper;

        public OrdersController(
            NorthwindContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
          if (_context.Orders == null)
          {
              return Problem("Entity set 'NorthwindContext.Orders'  is null.");
          }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //GET: api/Orders/Extended
        [HttpGet("Extended")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersExtended()
        {
            var orders = await _context.Orders
                .ToListAsync();

            if (orders == null)
            {
                return NotFound();
            }

            var orderDtos = new List<OrderDTO>();

            foreach (var order in orders)
            {
                var orderDto = _mapper.Map<OrderDTO>(order);
                var orderDetailsDtoList = await _context.OrderDetails
                .Where(od => od.OrderId == order.OrderId)
                .ProjectTo<OrderDetailDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

                orderDto.Customer = _mapper.Map<CustomerDTO>(await _context.Customers.FirstOrDefaultAsync(o => o.CustomerId == orderDto.CustomerId));
                orderDto.Employee = _mapper.Map<EmployeeDTO>(await _context.Employees.FirstOrDefaultAsync(o => o.EmployeeId == orderDto.EmployeeId));
                orderDto.OrderDetails = orderDetailsDtoList;
                foreach (var orderDet in orderDto.OrderDetails)
                {
                    var producto = await _context.Products.FirstOrDefaultAsync(o => o.ProductId == orderDet.ProductId);
                    orderDet.Product = _mapper.Map<ProductDTO>(producto);
                    orderDet.Product.Category = _mapper.Map<CategoryDTO>(await _context.Categories.FirstOrDefaultAsync(o => o.CategoryId == orderDet.Product.CategoryId));
                    orderDet.Product.Supplier = _mapper.Map<SupplierDTO>(await _context.Suppliers.FirstOrDefaultAsync(o => o.SupplierId == orderDet.Product.SupplierId));
                }
                orderDto.ShipViaNavigation = _mapper.Map<ShipperDTO>(await _context.Shippers.FirstOrDefaultAsync(o => o.ShipperId == orderDto.ShipVia));

                orderDtos.Add(orderDto);
            }

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            // Devuelve el resultado como JSON con formato e indentación
            return Content(JsonConvert.SerializeObject(orderDtos, jsonSettings), "application/json");

            //return orderDtos;
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
