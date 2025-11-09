

async function getUserData() {
    try {
        const response = await fetch("https://localhost:44386/api/User");
        if (!response.ok)
            throw new Error("error")

        else {
            const data = await response.json();
            alert(data);
        }
    }
    catch (e) {
        alert(e)
    }
}
async function Login() {
    try {
        const email = document.querySelector("#userName").value;
        const password = document.querySelector("#password").value;
        if (email == "" || password == "")
            throw Error("Please enter userName and password")
        const data = { email, password };
        const response = await fetch("https://localhost:44386/api/User/Login", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        
        if (!response.ok) {
            throw Error("New user, please register ")
        }
        
        else {
            const dataLogin = await response.json();
            sessionStorage.setItem('user', JSON.stringify(dataLogin))
            window.location.href = "Page2.html"

        }
    }
    catch (e) {
        alert(e)
    }
}
async function Register() { 
    try {
        const Email = document.querySelector("#userName2").value;
        const FirstName = document.querySelector("#firstName").value;
        const LastName = document.querySelector("#lastName").value;
        const Password = document.querySelector("#password2").value;
        const data = { Email, FirstName, LastName, Password };
        if (Email == "" || Password == "")
            throw Error("Please enter user name and password")
        const response = await fetch("https://localhost:44386/api/User", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        
        if (!response.ok)
            throw Error("error")
        const dataRegister = await response.json();
        alert("success")
        console.log('POST Data:', dataRegister)
    }
    catch (e) {
        alert(e)
    }
    
}


    