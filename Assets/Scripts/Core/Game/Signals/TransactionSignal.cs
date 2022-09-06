using Core.Transactions;

namespace Core.Game.Signals
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