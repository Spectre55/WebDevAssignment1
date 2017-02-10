function loginToggle()
{

    var form = document.getElementById('loginDiv');
    form.style.display = "block";
}

function toggle(id)
{
    var element = document.getElementById(id);

    if (element.style.display == "none")
    {
        element.style.display = "block";
        element.focus();
    }
    else
        element.style.display = "none";
}

function toggleOn(id)
{
    var element = document.getElementById(id);
    element.style.display = "block";
    element.focus();
}

function toggleOff(id) {
    var element = document.getElementById(id);
    element.style.display = "none";
}

/************************************************************************/

function closePopup()
{
    document.getElementsByClassName("popup").item[0].display = "none";
}
