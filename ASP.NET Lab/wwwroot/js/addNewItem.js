(function () {
    const alertElement = document.getElementById("success-alert");
    const formElement = document.forms[0];
    const nameInput = document.getElementById('add-name');
    const descInput = document.getElementById('add-desc');
    const visibleCheck = document.getElementById('add-visible');

    const addNewItem = async () => {
        // 1. read data from the form​
        const requestData = {
            Name: nameInput.value,
            Description: descInput.value,
            IsVisible: visibleCheck.checked
        }
        // 2. call the application server using fetch method
        const response = await fetch(
            '/api/formcontroller',
            {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(requestData)
            }
        );
        const responseJson = await response.json();
        console.log(responseJson);

        if (responseJson.success) {
            // 3. un-hide the alertElement when the request has been successful
            alertElement.style.display = "block";
            alertElement.innerHTML = responseJson.message;
        } else {
            console.log(responseJson);
        }
    };

    window.addEventListener("load", () => {
        formElement.addEventListener("submit", event => {
            event.preventDefault();
            addNewItem().then(() => console.log("added successfully"));
        });
    });
})();