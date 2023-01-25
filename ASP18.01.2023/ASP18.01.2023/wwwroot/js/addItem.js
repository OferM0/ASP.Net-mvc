//when click on input button the div with id "addItem" will be displayes and reverse
function addItem() {
    let divItem = //$("addItem"); 
        document.getElementById("addItem");
    if (divItem.style.display == "none") {
        divItem.style.display = ""
    } else {
        divItem.style.display = "none"
    }
}