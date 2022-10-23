import { Component, Profiler } from "react";
import Navigation from "../components/navigation";
import Profile from "../components/profiler";
import '../styles/Caregiver.css';
import img from './caregiver.png';



export default class Caregiver extends Component {
    render() {
        //render caregiver page
        return(
            <div className="caregiver-page">
                <Navigation />
                <Profile />
                <div className="caregiver">
                    <div className="caregiver-box left-box">
                        <h1>Care Giver 1</h1>
                        <div className="caregiver-summary">
                            <div className="caregiver-info">
                                <img src={img}>
                                </img>

                                <p>
                                    Caregiver Name<br/>
                                    Caregiver Position<br/>
                                    Caregiver Number<br/>
                                </p>
                            </div>
                            <hr />
                            <div className="comments">
                                <h3>Comment 1</h3>
                                <p>
                                    Lorum Ipsum
                                </p>
                                
                            </div>
                            <hr />
                            <div className="comments">
                                <h3>Comment 2</h3>
                                <p>
                                    Lorum Ipsum
                                </p>
                                
                            </div>
                            <hr />
                            <div className="comments">
                                <h3>Comment 3</h3>
                                <p>
                                    Lorum Ipsum
                                </p>
                                
                            </div>
                            <hr />
                        </div>


                    </div>

                    <div className="caregiver-box right-box">
                        <h1>Care Giver 2</h1>
                        <div className="caregiver-summary">
                            <div className="caregiver-info">
                                <img src={img}>
                                </img>

                                <p>
                                    Caregiver Name<br/>
                                    Caregiver Position<br/>
                                    Caregiver Number<br/>
                                </p>
                            </div>
                            <hr />
                            <div className="comments">
                                <h3>Comment 1</h3>
                                <p>
                                    Lorum Ipsum
                                </p>
                                
                            </div>
                            <hr />
                            <div className="comments">
                                <h3>Comment 2</h3>
                                <p>
                                    Lorum Ipsum
                                </p>
                                
                            </div>
                            <hr />
                            <div className="comments">
                                <h3>Comment 3</h3>
                                <p>
                                    Lorum Ipsum
                                </p>
                                
                            </div>
                            <hr />
                        </div>

                        
                    </div>

                </div>
            </div>
        )
    }
}