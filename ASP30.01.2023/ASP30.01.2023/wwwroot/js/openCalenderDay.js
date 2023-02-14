function toggleRows() {
    var targetRows = document.querySelectorAll('.toggle-target');
    for (var i = 0; i < targetRows.length; i++) {
        targetRows[i].style.display = 'none';
    }

    var toggleRows = document.querySelectorAll('.toggle-row');
    for (var j = 0; j < toggleRows.length; j++) {
        toggleRows[j].addEventListener('click', function () {
            var nextRows = this.nextElementSibling;
            while (nextRows && !nextRows.classList.contains('toggle-row')) {
                nextRows.style.display = nextRows.style.display === 'none' ? '' : 'none';
                nextRows = nextRows.nextElementSibling;
            }
        });
    }
}