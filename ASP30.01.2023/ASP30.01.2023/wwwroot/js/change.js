function change(day) {
    let div =
        document.getElementById(day);
    if (div.style.display == "none") {
        div.style.display = ""
    } else {
        div.style.display = "none"
    }
}