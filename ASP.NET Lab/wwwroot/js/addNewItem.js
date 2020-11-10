(function () {
    const alertElement = document.getElementById("success-alert");
    const formElement = document.forms[0];
    const addNewItem = async () => {
        // 1. read data from the form​
        const requestData = {
            Name: 'a',
            Description: 'b',
            IsVisible: true
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
        if (responseJson.success) {
            // 3. un-hide the alertElement when the request has been successful
            alertElement.style.display = "block";
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