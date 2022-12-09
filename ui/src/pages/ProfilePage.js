import { Component, useEffect,useState} from "react";
import { Link } from "react-router-dom";
import Navigation from "../components/navigation";
import '../styles/ProfilePage.css';
import { Button } from "react-bootstrap";
import Auth from "../Auth";
import React from "react";
import BounceLoader from "react-spinners/BounceLoader";
import Cookies from 'js-cookie';
import ReactDOM from 'react-dom';
import { render } from "@testing-library/react";
import behaviour from './images/behaviour.jpg';
import careplan from './images/careplan.jpg';
import medicalhistory from './images/medicalhistory.png';
import medication from './images/medication.jpg';
import caregiver from './images/caregiver.jpg';
import falltracker from './images/falltracker.webp';


//log user out and remove cookies
function logout() {
   Cookies.remove('name')
   Cookies.remove('userInfo')
   Auth.logout();
   window.location.href = '/';   
}

class UserID extends Component{
    constructor(props){
        super(props)
        let info ;
        let email;
        

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
            //Fetch request to get profile info for the user and store it a coolies
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
                 info = data[0]
            
                    const element = <div>
                        <div><h2>{" Hello, " + info.FirstName +" "+ info.LastName}</h2></div>
                        <div>{info.Address}</div>
                    </div>;

                    ReactDOM.render(element, document.getElementById('fulldetail'));
                    Cookies.set('userInfo',JSON.stringify(data) , { expires:1});
                    
                }
         );
}
    render( ){
        return (
            <div class="media"  id ="fulldetail">
                
            </div>
        );}
}


export default function ProfilePage(){
    const [loading, setLoading] = useState(false);

    useEffect(() =>{
        setLoading(true)
        setTimeout(() =>{
            setLoading(false)

        },2500)
    },[])
    return (
        <div className="loadAnimate">
            {
                loading ? <div className="loadCenter"><BounceLoader size = {200} color = {"#F5A623"}
                loading = {loading}/></div>
                :<Profile/>
            }</div>
    )
}

class Profile extends Component{
    constructor(props){
        super(props);
    
    }
    render() {
        return(
            <React.Fragment >
            <div className="profilepage">
                <Navigation />
                <div className="profile">
                    <div className="left-side">
                        <UserID/>
                        <div >
                            <button className="btn btn-outline-danger" onClick={logout}>Logout</button>
                        </div>
                    </div> 
                    <div className="right-side">
                        <img className= "profileImg"  src={"https://storage.needpix.com/rsynced_images/profile-2398782_1280.png"}></img>
                        <Link to='#'><button className="btn btn-primary edit-profile" onClick={logout}>Edit Profile</button></Link>
                    </div>
                </div>
                <div class="container">

                    <div class="row">

                            <div class="col-md-4">
                                <div className="col-content">
                                    <div className="image">
                                        <img src={behaviour}></img>
                                    </div>
                                    <div className="col-text-content">
                                        <h2>
                                            Behaviour Tracker
                                        </h2>
                                        <p>
                                            View and update your profile.
                                        </p>
                                        <Link to='/BehaviourTracker'><Button>Go</Button></Link>

                                    </div>
                                </div>
                                
                                
                            </div>

                            <div class="col-md-4">
                                <div className="col-content">
                                    <div className="img">
                                        <img src={careplan}></img>
                                    </div>

                                    <div className="col-text-content">
                                        <h2>
                                            Behaviour Care Plan
                                        </h2>
                                        <p>
                                            View your care plan(s).
                                        </p>
                                        <Link to='/Careplan'><Button>Go</Button></Link>
                                    </div>
                                </div>
                                
                                
                            </div>

                            <div class="col-md-4">
                                <div className="col-content">
                                    <div className="img">
                                        <img src={medication}></img>
                                    </div>

                                    <div className="col-text-content">
                                        <h2>
                                            Medication List
                                        </h2>
                                        <p>
                                            Review your current medication(s) here.
                                        </p>
                                        <Link to='/MedicationList'><Button>Go</Button></Link>
                                    </div>
                                </div>
                                
                                
                            </div>
                    </div>

                    <div class="row">

                            <div class="col-md-4">
                                <div className="col-content">
                                    <div className="img">
                                        <img src={medicalhistory}></img>
                                    </div>

                                    <div className="col-text-content">
                                        <h2>
                                            Medical History
                                        </h2>
                                        <p>
                                            Check your clinical visits and history here.
                                        </p>
                                        <Link to='/History'><Button>Go</Button></Link>
                                    </div>
                                </div>
                                
                                
                            </div>

                            <div class="col-md-4">
                                <div className="col-content">
                                    <div className="img">
                                        <img src={caregiver}></img>
                                    </div>

                                    <div className="col-text-content">
                                        <h2>
                                            CareGiver
                                        </h2>
                                        <p>
                                            View your caregiver(s) and their information
                                        </p>
                                        <Link to='/Caregiver'><Button>Go</Button></Link>
                                    </div>
                                </div>
                                
                                
                            </div>

                            <div class="col-md-4">
                                <div className="col-content">
                                    <div className="img">
                                        <img src={falltracker}></img>
                                    </div>

                                    <div className="col-text-content">
                                        <h2>
                                            Falls Tracker
                                        </h2>
                                        <p>
                                            Review your current medication(s) here.
                                        </p>
                                        <Button>Go</Button>
                                    </div>
                                </div>
                                
                            </div>
                    </div>
                </div>
            </div>
            
            </React.Fragment>
        )
    }
}

