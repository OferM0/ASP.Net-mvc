//when click on input button the div with id "addItem" will be displayes and reverse
function addHaircut() {
    let divHaircut = //$("addHaircut"); 
        document.getElementById("addHaircut");
    if (divHaircut.style.display == "none") {
        divHaircut.style.display = ""
    } else {
        divHaircut.style.display = "none"
    }
}