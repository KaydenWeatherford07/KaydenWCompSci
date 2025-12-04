


namespace CompSci.zClasswork.Lab10
{
    class Stack<T> {
        private int MaxSize;
        private int TopOfStack;
        private T[] arr;
    
    
        public Stack(int maxSize)
        {
            MaxSize = maxSize;
            arr = new T[maxSize];
            TopOfStack = -1;
        }
        

        // Methods:
        public void Push(T a) {
            if (TopOfStack == (MaxSize - 1))
            {
                throw new ArgumentException("Stack is full");
            }
            TopOfStack++;
            arr[TopOfStack] = a;
        }

        public T Pop(){
            if (TopOfStack == -1)
                throw new ArgumentException("Stack is empty");
            TopOfStack--;
            return arr[TopOfStack+1];
        }

        public T Peek(){
            if (TopOfStack == -1)
                throw new ArgumentException("Stack is empty");
            return arr[TopOfStack];
        }

        public int Size()
        {
            return TopOfStack + 1;
        }
    }
}