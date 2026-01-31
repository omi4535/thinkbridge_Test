
    function getinvoice() {

        const apiUrl = `http://localhost:5081/api/Data/`; // change port
        fetch(apiUrl)
            .then(res => {
                if (!res.ok) throw new Error("invoice not found");
                return res.json();
            })
            .then(data => {
              
               
                document.getElementById("Invoice-id").innerText = data.invoiceID;
                document.getElementById("Customer-name").innerText = data.customerName;

                let output = "";

                output += "items:\n";

                data.items.forEach(item => {
                    output += " - " + item.name + " :" + item.price + "\n";
                });

                document.getElementById("itemDeatials").innerText = output;
                console.log(data);
            })
            .catch(err => {
                document.getElementById("invoicediv").innerText = "error";
            });
    }

