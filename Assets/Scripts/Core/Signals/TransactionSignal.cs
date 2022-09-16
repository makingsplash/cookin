using Core.Transactions;

namespace Core.Signals
{
    public class TransactionSignal
    {
        public Transaction Transaction;

        public TransactionSignal(Transaction transaction)
        {
            Transaction = transaction;
        }
    }
}