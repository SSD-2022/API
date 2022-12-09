import { Component } from "react";
import Navigation from "../components/navigation";
import '../styles/LoginPage.css';
import {Link} from 'react-router-dom';
import Cookies from 'js-cookie';
import ProtectedRoutes from "../ProtectedRoute";
import Auth from "../Auth";


//Check if user is already logged in, will not let user log in twice
export default function checkCookie(){

    if(Cookies.get('name')){
    window.location.href = '/Profile';
    }
    return(
        <Login/>
    )
}

class Login extends Component {
    constructor(props){
        super(props);
        
        this.handleSignin = this.handleSignin.bind(this);

    }
    handleSignin(event) {
        let myEmail = document.getElementById('email').value;
        myEmail = myEmail.toLowerCase();
        // fetch request to verify user
    fetch(process.env.REACT_APP_API+'userinfoes',
        {
            method : 'POST',
            headers:{
            'Accept': 'application/json',
            'Content-Type' : 'application/json'
            //URLSearchParams: 
            
        },
            body : JSON.stringify(
                {
                    emailAdd : myEmail,
                    password : document.getElementById('password').value,

                })
            }).then(res=>res.status).then(async (result) => {
                if (result == 200){
                    //Log user in and setup cookies and redirect user to profile Page
                    Auth.login();
                    
                    
                    Cookies.set('name',myEmail , { expires:7})
                    window.location.href = '/Profile'; }
                else{
                    // Error Landling if logins are incorrect
                    alert("Invalid Logins!! Please Try Again")
                }
            },(error) =>{
                console.log(error);
                alert('failed')
             })
    event.preventDefault();
    

    }
    render() {
        return(
            <div>
                <Navigation />
                <div className="login-form">
                    <form onSubmit={this.handleSignin}>
                        <fieldset>
                            <legend>Login</legend>
                            <label for='email'>Email</label><br />
                            <input type='email' id='email'/><br />
                            <label for='password'>Password</label><br />
                            <input type='password' id='password' /><br />
                            <input type="checkbox" value="lsRememberMe" id="rememberMe" /> 
                            <label for="rememberMe">Remember me</label><br />
                            <input type="submit" value="Login" onclick="lsRememberMe()"/>
                            <label for="noAccount">Don't have an account?</label>
                            <Link to='/Signup'><input type="submit" value="Sign Up!" onclick="lsRememberMe()"></input></Link>
                
                        </fieldset>
                    </form>
                </div>
            </div>

            
        )
    }
}


