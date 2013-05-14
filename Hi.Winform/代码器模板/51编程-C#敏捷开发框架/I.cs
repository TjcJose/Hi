/// <summary>
/// $TableRemark$
/// </summary>
/// <returns></returns>
public static I$ClassName$Dal Create$ClassName$Dal()
{
    string className = path + ".$ClassName$Dal";
    return (I$ClassName$Dal)Assembly.Load(path).CreateInstance(className);
}
