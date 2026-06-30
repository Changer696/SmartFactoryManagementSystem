using System;
using System.Reflection.Metadata.Ecma335;

public class ProductionOrder
{
	private int? orderId
	{
		get; set;
	}
	private int? targetQuantity
	{
        get; set;
    }
    private int? producedQuantity
    {
        get; set;
    }
    private enum Priority
    {
        Low ,Medium,High
    }
    private DateTime createddDate { get; set; }
    bool isCompleted { get; set; }


}
