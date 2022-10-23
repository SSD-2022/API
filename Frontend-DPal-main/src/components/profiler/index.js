import { Component } from "react";
import { Link } from "react-router-dom";
import './style.css';
import Auth from "../../Auth";
import Cookies from 'js-cookie';
import ReactDOM from 'react-dom';
import React from "react";

//Log user out with this function
function logout() {
    Auth.logout();
    window.location.href = '/';
} 

//Setting users name in the profile
function UserID(){
    
    let info ;
    let email;

    //Log user out if no email is associated with the session, return to login page
    try {
        email = Cookies.get('name');
        if (email.length < 1){
            alert("session expired")
            window.location.href = '/Login';
        }
        
    }
    catch(error){
        window.location.href = '/Login';
    }
    fetch(process.env.REACT_APP_API+'profileinfoes',
        {
            method : 'POST',
            headers:{
            'Accept': 'application/json',
            'Content-Type' : 'application/json'
        },
            body : JSON.stringify(
                { emailAdd : email })
            })
        .then(response => response.json())
        .then((data) => {
            //set data to users current info
            info = data[0]
            console.log(info.FirstName,info.LastName,info.Address)
            const element = <div>
                <div>{info.FirstName +" "+ info.LastName}</div>
                <div>{info.Address}</div>
            </div>;
            ReactDOM.render(element, document.getElementById('fulldetail'));


        }
);
  return (
    <div class="media">
  <div class="media-body" id = "fulldetail">
  </div>
</div>
);
}

//render profile component
class Profiler extends Component {
    shouldComponentUpdate(newProps){
        return false;
    }
    render() {
        
        return(
            <div className="profile-component">
                <div className="profile-box">
                    <div className="left-side">
                        <UserID  />
                        <button className="btn btn-outline-danger" onClick={logout}>Logout</button>
                    </div> 
                    <div className="right-side">
                        <img className= "profileImg"  src={"https://storage.needpix.com/rsynced_images/profile-2398782_1280.png"}></img>
                        <Link to='/Profile'><button className="btn btn-primary edit-profile">Profile</button></Link>
                    </div>
                </div>
            </div>
        )
    }
}

export default Profiler;