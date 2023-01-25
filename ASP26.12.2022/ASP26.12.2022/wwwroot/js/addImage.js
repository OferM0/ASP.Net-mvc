//when click on input button the div with id "addImage" will be displayes and reverse
function addImage() {
    let divImage = //$("addImage"); 
    document.getElementById("addImage");
    if (divImage.style.display == "none") {
        divImage.style.display = ""
    } else {
        divImage.style.display = "none"
    }
}