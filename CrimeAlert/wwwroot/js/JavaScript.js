
document.addEventListener("DOMContentLoaded", () => {
    const storedImages = JSON.parse(localStorage.getItem("images")) || [];

    if (storedImages.length > 0) {
        const imageRows = document.getElementById("imageRows");

        storedImages.forEach((imgData) => {
            const newRow = imageRows.insertRow();
            const cell1 = newRow.insertCell(0);
            const cell2 = newRow.insertCell(1);
            const cell3 = newRow.insertCell(2);
            const cell4 = newRow.insertCell(3);
            const cell5 = newRow.insertCell(4);
            const cell6 = newRow.insertCell(5);
            /*   const cell7 = newRow.insertCell(6);*/

            cell1.innerHTML = `<img class="imgPreview" src="${imgData}" style="max-height: 100px;" alt="Preview">`;
            cell2.innerHTML = "";
            cell3.innerHTML = "";
            cell4.innerHTML = "";
            cell5.innerHTML = "";
            cell6.innerHTML = "";
            /*        cell7.innerHTML = `<button class="delete-row" onclick="deleteRow(this)">Delete</button>`;*/
        });
    }
});

document.querySelector("#myFileInput").addEventListener("change", function () {
    const reader = new FileReader();

    reader.addEventListener("load", () => {
        const newRow = imageRows.insertRow();
        const cell1 = newRow.insertCell(0);
        const cell2 = newRow.insertCell(1);
        const cell3 = newRow.insertCell(2);
        const cell4 = newRow.insertCell(3);
        const cell5 = newRow.insertCell(4);
        const cell6 = newRow.insertCell(5);
        /*        const cell7 = newRow.insertCell(6);*/

        cell1.innerHTML = `<img class="imgPreview" src="${reader.result}" style="max-height: 100px;" alt="Preview">`;
        cell2.innerHTML = "";
        cell3.innerHTML = "";
        cell4.innerHTML = "";
        cell5.innerHTML = "";
        cell6.innerHTML = "";
        /*     cell7.innerHTML = `<button class="delete-row" onclick="deleteRow(this)">Delete</button>`;*/

        const storedImages = JSON.parse(localStorage.getItem("images")) || [];
        storedImages.push(reader.result);
        localStorage.setItem("images", JSON.stringify(storedImages));
    });

    reader.readAsDataURL(this.files[0]);
});

function deleteRow(button) {
    const row = button.parentElement.parentElement;
    row.remove();
    const storedImages = JSON.parse(localStorage.getItem("images")) || [];
    const imgSrc = row.cells[0].querySelector("img").src;
    const index = storedImages.indexOf(imgSrc);
    if (index > -1) {
        storedImages.splice(index, 1);
        localStorage.setItem("images", JSON.stringify(storedImages));
    }
}
