import React, { Component } from "react";
import Cookies from 'js-cookie';

// This popup will be rendered when add medication Button Is clicked
export default class PopUp extends Component {
    handleClick = () => {
        this.props.toggle();
        

    };
    handleSave = (event)=>{
        let email;
        try {
            email = Cookies.get('name');
            if (email.length < 1) {
                alert("session expired")
                window.location.href = '/Login';
            }

        }
        catch (error) {
            window.location.href = '/Login';
        }
        //fetch request for list of all medications error handling as also been added
        fetch(process.env.REACT_APP_API + 'medicationlists',
            {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(
                    {
                        emailAdd: email,
                        medName: document.getElementById('medName').value,
                        medDescp: document.getElementById('medDesc').value,
                        dosage: document.getElementById('medDosage').value


                    })
            }).then(res => res.status).then((result) => {
                if (result = 200) {
                    window.location.href = '/MedicationList'
                    this.props.toggle();
                }
                else {
                    prompt("internal Server Error")
                }
            },(error) => {
                window.location.href = '/MedicationList'
                //alert('failed')
            })
        event.preventDefault();

    }

    render() {
        return (
            
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalCenterTitle">Add Medication</h5>
                        </div>
                        <div class="modal-body">
                            
                        <div class="input-group input-group-lg" style={{ margin: "7px 7px 7px 7px" }}>
                            <div class="input-group-prepend" > 
                                <span class="input-group-text" id="inputGroup-sizing-lg">Medicine Name</span>
                            </div>
                            <input id = "medName" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing" style={{ padding: "0rem" }}/>
                        </div>
                        <div class="input-group" style={{ margin: "7px 7px 7px 7px" }}>
                            <textarea id="medDesc" class="form-control" aria-label="With textarea" placeholder="Description Of Medication"></textarea>
                        </div>


                        <div class="input-group input-group-lg" style={{ margin: "7px 7px 7px 7px" }}>
                            <div class="input-group-prepend">
                                <span class="input-group-text" id="inputGroup-sizing-lg">Dosage</span>
                            </div>
                            <input id="medDosage" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing" style={{ padding: "0rem" }} />
                        </div>

                        </div>
                        <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" onClick={this.handleClick}>Close</button>
                        <button type="button" class="btn btn-primary" onClick={this.handleSave}>Add To List</button>
                        </div>
                    </div>
                </div>
            
        );
    }
}
