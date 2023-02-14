function closeTags() {
    let divTags = document.getElementsByClassName("tag");
    for (let i = 0; i < divTags.length; i++) {
        let divTag = divTags[i];
        if (divTag.style.display === "none") {
            divTag.style.display = "";
        } else {
            divTag.style.display = "none";
        }
    }

    let divTag2 = document.getElementById("selectedTag");
    if (divTag2.style.display == "none") {
        divTag2.style.display = ""
    } else {
        divTag2.style.display = "none"
    }
}