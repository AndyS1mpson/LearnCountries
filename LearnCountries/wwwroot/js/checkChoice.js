function checkChoice()
{
    console.log('lol');
        var check_list = ["check1", "check2", "check3","check4","check"];
        var span_list = ["lab1", "lab2", "lab3","lab4","capitalLab"];
                    
        for (var i = 0; i < 4; i++)
        {
            if(document.getElementById(check_list[i]).value == document.getElementsByName('capitalName')[0].value)
            {
                   document.getElementById(span_list[i]).style.background = "green";
            }
            else {
                document.getElementById(span_list[i]).style.background = "red";
           
            } 
        }  
}