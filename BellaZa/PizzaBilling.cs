using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellaZa
{
    public class BillingRequest
    {
        private Pizza pizza;
    }

    public class PizzaBilling
    {
        public interface IBillingHandler
        {
            IBillingHandler SetNext(IBillingHandler handler);

            object Handle(object request);
        }
        abstract class AbstractBillingHandler : IBillingHandler
        {
            private IBillingHandler _nextHandler;

            public IBillingHandler SetNext(IBillingHandler handler)
            {
                this._nextHandler = handler;
                return handler;
            }

            public virtual object Handle(object request)
            {
                if (this._nextHandler != null)
                {
                    return this._nextHandler.Handle(request);
                }
                else
                {
                    return null;
                }
            }
        }
        class DeliveryBillingHandler : AbstractBillingHandler
        {
            public override object Handle(object request)
            {
                if ((request as string) == "Banana")
                {
                    return $"Monkey: I'll eat the {request.ToString()}.\n";
                }
                else
                {
                    return base.Handle(request);
                }
            }
        }
        class DeliveryHandler : AbstractBillingHandler
        {
            public override object Handle(object request)
            {
                if ((request as string) == "Banana")
                {
                    return $"Monkey: I'll eat the {request.ToString()}.\n";
                }
                else
                {
                    return base.Handle(request);
                }
            }
        }
    }
}
