import { Component, Profiler } from "react";
import { useEffect, useState } from "react";
import Navigation from "../components/navigation";
import '../styles/MedicationList.css';
import Profile from "../components/profiler";
import HashLoader from "react-spinners/HashLoader";
import React from "react";
import PopUp from "./Popup.js"; 
import axios from "axios";
import Cookies from 'js-cookie';
import { render } from "@testing-library/react";


// Render Medication List Page After rendering 
export default function MedicalList() {
    //set animation on page load
    const [loading12, setLoading12] = useState(false);
    
    useEffect(() => {
        setLoading12(true)
        setTimeout(() => {
            setLoading12(false)

        }, 2000)
    }, [])
    return (
        <div className="loadAnimate">
            {
                loading12 ? <div className="loadCenter"><HashLoader size={200} color={"#74C38D"}
                    loading12={loading12} /></div>
                    : <MList />
            }</div>
    )
}


class GetList extends Component {
    constructor(props) {
        super(props);

        this.state = {
            meditems : []
        };
        

    }
    //set medication list for account
    componentDidMount(){
        let email = Cookies.get('name');
        axios.get(process.env.REACT_APP_API + 'medicationlists?emailAdd=' + email)
            .then(response => {

            this.setState({ meditems : response.data});
            
            
            }
        )
    }
    

    render(){
        const { meditems } = this.state;
        console.log(meditems);
        //console.log(meditems);
        return (
            <div className="card text-center m-3">
                <div class="alert alert-light" >
                    <h1 class="col-sm"> Your medication Will Appear Here</h1>
                </div>
                <div>{ meditems.map(item =>

                    < li class="list-group-item" style={{ "text-align" : "initial"}}> 
                        <div class="card" >
                            <h5 class="card-header">Medicine : {item['MedName']}</h5>
                            <div class="card-body">
                                <blockquote class="blockquote mb-0">
                                    <p>{item['MedDescp']}</p>
                                    <footer class="blockquote-footer">Dosage: {item['Dosage']} </footer>
                                </blockquote>

                            </div>
                            </div>
                    </li>
                    )}
                </div>
            </div>
             
           
        );  
    }    
}


 class MList extends Component {
    constructor(props) {
        super(props);
        this.state = {seen: false};

        this.togglePop =this.togglePop.bind(this);
     
    }
     togglePop = () => {
        this.setState({
            seen: !this.state.seen
        });
        
    };
    render() {
        
        return (
            <div>
                <Navigation />
                <Profile />
            <div class="container-xl " >
                <div class="col-lg-auto">
                    
                        </div>
                <div class="row">
                    
                    </div>

                <div class="medication-list container-lg">
                    <div class="medication-list row">
                        <div class="col-sm">
                        </div>
                        <div class="col-6">
                        </div>
                        
                        <div> 
                            <GetList/>
                        </div>
                        <button type="button" class="medication-list info-button" onClick={this.togglePop} data-mdb-ripple-color="dark">
                            Add Medication</button>
                            <div style={{ "position": "absolute" }} >
                                {this.state.seen ? <PopUp  toggle={this.togglePop} /> : null}
                            </div>

                        </div>
                </div>
                <div class="col-sm">
                </div>
                <div class="row">
                
                </div>

            </div>
            </div>
        )
    }
}



