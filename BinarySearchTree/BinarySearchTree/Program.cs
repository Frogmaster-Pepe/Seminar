using System.Xml.Linq;

namespace BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>();
            binarySearchTree.Insert(4, "a");
            binarySearchTree.Insert(1, "b");
            binarySearchTree.Insert(7, "c");
            binarySearchTree.Insert(30, "d");
            binarySearchTree.Insert(5, "e");
            binarySearchTree.Insert(2, "f");

            binarySearchTree.ShowTree();
            binarySearchTree.FindMin();
            binarySearchTree.Find(2);
            binarySearchTree.Delete(2);
            binarySearchTree.ShowTree();

        }
    }

    class BinarySearchTree<T>
    {
        public Node<T> Root;

        public void Insert(int newKey, T newValue)
        {

            void _insert(Node<T> node, int newKey, T newValue)
            {
                if (newKey < node.Key) // jdeme doleva
                    if (node.LeftSon == null)
                        node.LeftSon = new Node<T>(newKey, newValue);
                    else
                        _insert(node.LeftSon, newKey, newValue);
                else if (newKey > node.Key) // jdeme doprava
                    if (node.RightSon == null)
                        node.RightSon = new Node<T>(newKey, newValue);
                    else
                        _insert(node.RightSon, newKey, newValue);
                else // našli jsme náš klíč, což bychom neměli, mají být unikátní.... :/
                    throw new Exception(); // vyhodíme chybu
            }

            if (Root == null) // pokud ještě není definován kořen
                Root = new Node<T>(newKey, newValue);
            else
                _insert(Root, newKey, newValue);
        }
        public void Find(int key)
            {
                void _find(Node<T> node, int key)
                {
                    if (node == null) 
                    {
                        Console.WriteLine("Nenalezeno.");
                        return;     
                    }
                    if (key == node.Key) 
                    {
                        Console.WriteLine($"Nalezeno: [{node.Key}] = \"{node.Value}\""); 
                        return; 
                    }
                    if (key < node.Key)
                    {
                        _find(node.LeftSon, key);
                    }
                    else
                    {
                        _find(node.RightSon, key);
                    }
                }
            

                _find(Root, key);
            }

        public void FindMin()
        {
            void _findMin(Node<T> node)
            {
                if (node.LeftSon == null) 
                { 
                    Console.WriteLine($"Minimum: [{node.Key}] = \"{node.Value}\""); 
                    return; 
                }
                else 
                    _findMin(node.LeftSon);
            }

            if (Root == null)
            {
                Console.WriteLine("Strom je prázdný.");
            }
            else
                _findMin(Root);
        }

        public void Delete(int key)
        {
            Node<T> _findMin(Node<T> node)
            {
                return node.LeftSon == null ? node : _findMin(node.LeftSon);
            }

            Node<T> _delete(Node<T> node, int key)
            {
                if (node == null) 
                { 
                    Console.WriteLine("Klíček nenalezen."); 
                    return null; 
                }

                if (key < node.Key)
                {
                    node.LeftSon = _delete(node.LeftSon, key);
                }
                else if (key > node.Key)
                {
                    node.RightSon = _delete(node.RightSon, key);
                }
                else
                {
                    if (node.LeftSon == null) return node.RightSon;
                    if (node.RightSon == null) return node.LeftSon;

                    // Vrchol má dva syny – nahradíme dalším nástupcem
                    Node<T> successor = _findMin(node.RightSon);
                    node.Key = successor.Key;
                    node.Value = successor.Value;
                    node.RightSon = _delete(node.RightSon, successor.Key);
                }

                return node;
            }

            Root = _delete(Root, key);
            Console.WriteLine($"Vrchol {key} odstraněn.");
            Console.WriteLine(); 
        }
            public void ShowTree()
            {
                if (Root == null)
                {
                    Console.WriteLine("Strom neni, někdo ho asi pokácel");
                }
                void _print(Node<T> node)
                {
                
                    if (node == null) return;
                    if (node.LeftSon != null)
                    {
                         _print(node.LeftSon);
                    }

                    Console.WriteLine($"{node.Key}:{node.Value}");
                    
                    

                    if (node.RightSon != null)
                    {
                        _print(node.RightSon);
                    }

                   
                }
                Console.WriteLine("Tady je stromeček");
                    _print(Root);
                Console.WriteLine();
        }
    }


    class Node<T> // T může být libovolný typ
    {
        public Node(int key, T value)
        {
            Key = key;
            Value = value;
        }
        public int Key;
        public T Value;

        public Node<T> LeftSon;
        public Node<T> RightSon;
    }

}
