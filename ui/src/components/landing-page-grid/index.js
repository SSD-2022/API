import { Component } from "react";
import { Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import './landing-page-grid.css';
import profile from './images/profile.jpg';
import behaviour from './images/behaviour.jpg';
import medication from './images/medication.jpg';
import medicalhistory from './images/medicalhistory.png';



class LandingGrid extends Component {
    render() {
        return(
            <div className="landing-grid">
                <div class="container">
                    <div class="row gx-5">
                        <div class="col-md-3">
                            <div className="col-content">
                                <div className="img">
                                    <img src={profile}></img>
                                </div>
                                <h2>
                                    My Profile
                                </h2>
                                <p>
                                    View and update your profile.
                                </p>
                                <Link to='/Profile'><Button>Go</Button></Link>
                            </div>
                            
                        </div>
                        <div class="col-md-3">
                            <div className="col-content">
                                <div className="img">
                                    <img src={behaviour}></img>
                                </div>
                                <h2>
                                    Behaviour Tracker
                                </h2>
                                <p>
                                    Create or update a behaviour tracker here.
                                </p>
                                <Link to='/BehaviourTracker'><Button>Go</Button></Link>
                            </div>
                            
                        </div>
                        <div class="col-md-3">
                            <div className="col-content">
                                <div className="img">
                                    <img src={medication}></img>
                                </div>
                                <h2>
                                    Medication List
                                </h2>
                                <p>
                                    Review your current medication(s) here.
                                </p>
                                <Link to='/MedicationList'><Button>Go</Button></Link>
                            </div>
                        </div>
                        
                        <div class="col-md-3">
                        <div className="col-content">
                            <div className="img">
                                    <img src={medicalhistory}></img>
                                </div>
                                <h2>
                                    Medical History
                                </h2>
                                <p>
                                    View your medical history here.
                                </p>
                                <Link to='/History'><Button>Go</Button></Link>
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
        )
    }
}

export default LandingGrid;