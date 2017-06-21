using System;
using System.Collections;
using System.Collections.Generic;

public class myNonceSet
{
    /* Our DT size */
    private int Count = 0;

    //For containing the set
    private Node<int> myFirstNode = null;
    //For inserting the set
    private Node<int> myLastNode = null;
    //For deleting purpuses
    private Node<int> mySixtyNode = null;
    /*Add an integer item to set O(100)~O(1)*/
    public bool Add(int item)
    {
        bool Output = !Contains(item);
        if (Output)
        {
            if (myFirstNode == null)
            {
                myLastNode = new Node<int>(item);
                myFirstNode = myLastNode;
            }
            else
            {
                myLastNode.SetNext(new Node<int>(item));
                myLastNode = myLastNode.GetNext();
            }
            Count++;
            Output = true;

            if (Count == 61)
                mySixtyNode = myLastNode;
            if (Count == 181)//we delete the nonces of the minute before
                CleanLastSixstyObjects();
        }
        //Console.WriteLine(item + " " + Output);
        return Output;
    }

    /* delete all the first 60 numbers
        * becasue every minute the server nonces are reset, and every second only 120 objects can join the set and we have > 180
        * O(1)*/
    private void CleanLastSixstyObjects()
    {
        if (mySixtyNode != null)
        {
            myFirstNode = mySixtyNode;
            Count = Count - 60;
            mySixtyNode = myFirstNode;
            for (int i = 0; i < 60; i++)
                mySixtyNode = mySixtyNode.GetNext();
        }
    }

    /*return true if the set contain the nonce*/
    private bool Contains(int item)
    {
        bool Output = false;
        Node<int> current = myFirstNode;
        while (!Output & current != null)
        {
            if (current.GetInfo().Equals(item))
                Output = true;
            current = current.GetNext();
        }
        return Output;
    }
}
