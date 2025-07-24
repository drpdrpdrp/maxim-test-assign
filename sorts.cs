
public static class QuickSorter
{
    public static void QuickSort<T>(T[] array) where T : IComparable<T>
    {
        QuickSort(array, 0, array.Length - 1);
    }

    private static void QuickSort<T>(T[] array, int left, int right) where T : IComparable<T>
    {
        if (left >= right)
            return;

        int pivotIndex = Partition(array, left, right);
        QuickSort(array, left, pivotIndex - 1);
        QuickSort(array, pivotIndex + 1, right);
    }

    private static int Partition<T>(T[] array, int left, int right) where T : IComparable<T>
    {
        T pivot = array[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (array[j].CompareTo(pivot) <= 0)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, right);
        return i + 1;
    }

    private static void Swap<T>(T[] array, int i, int j)
    {
        if (i != j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

public class TreeNode<T> where T : IComparable<T>
{
    public TreeNode(T data)
    {
        Data = data;
    }

    public T Data { get; set; }

    public TreeNode<T>? Left { get; set; }

    public TreeNode<T>? Right { get; set; }

    public void Insert(TreeNode<T> node)
    {
        if (node.Data.CompareTo(Data) <= 0)
        {
            if (Left == null)
                Left = node;
            else
                Left.Insert(node);

        }
        else
        {
            if (Right == null)
                Right = node;
            else
                Right.Insert(node);

        }
    }

    public T[] Transform(List<T>? elements = null)
    {
        if (elements == null)
        {
            elements = new List<T>();
        }

        if (Left != null)
        {
            Left.Transform(elements);
        }

        elements.Add(Data);

        if (Right != null)
        {
            Right.Transform(elements);
        }

        return elements.ToArray();
    }


    public static T[] TreeSort(T[] array)
    {
        var treeNode = new TreeNode<T>(array[0]);
        for (int i = 1; i < array.Length; i++)
        {
            treeNode.Insert(new TreeNode<T>(array[i]));
        }

        return treeNode.Transform();
    }

}
