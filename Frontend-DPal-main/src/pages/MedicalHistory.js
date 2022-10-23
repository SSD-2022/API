import { Component ,Profiler} from "react";
import Navigation from "../components/navigation";
import '../styles/MedicalHistory.css';
import Profile from "../components/profiler";
import { useEffect,useState} from "react";
import RingLoader from "react-spinners/RingLoader";   
import axios from "axios";
import Cookies from 'js-cookie';


// render Medical history Page after Loading 
export default function MedicalHistory(){
    const [loading13, setLoading13] = useState(false);

    useEffect(() =>{
        setLoading13(true)
        setTimeout(() =>{
            setLoading13(false)

        },2000)
    },[])
    return (
        <div className="loadAnimate">
            {
                loading13 ? <div className="loadCenter"><RingLoader size = {200} color = {"#74C38D"}
                loading13 = {loading13}/></div>
                :<MHistory/>
            }</div>
    )
}


class MHistory extends Component {
    constructor(props) {
        super(props);
        this.state = { value: '' };

        this.handleSubmit = this.handleSubmit.bind(this);

    }
    handleSubmit(e){
        e.preventDefault();
        
        axios({
            //set data after checking if checkboxes were checked
            method: 'post',
            url: process.env.REACT_APP_API + 'medicalhistories',
            data: {
                emailAdd :  Cookies.get('name'),
                Depression: (document.getElementById('Depression').checked),
                NeurologicDisorder: (document.getElementById('NeurologicDisorder').checked),
                HeartDisease: (document.getElementById('HeartDisease').checked),
                Stroke: (document.getElementById('Stroke').checked),
                HypertensiveDisorders: (document.getElementById('HypertensiveDisorders').checked),
                RespiratoryDisease: (document.getElementById('RespiratoryDisease').checked),
                Hepatie: (document.getElementById('Hepatie').checked),
                ConnectiveTissue: (document.getElementById('ConnectiveTissue').checked),
                Musculoskeletal: (document.getElementById('Musculoskeletal').checked),
                EndocrineMetabolic: (document.getElementById('EndocrineMetabolic').checked),
                HematopoieticLymahane: (document.getElementById('HematopoieticLymahane').checked),
                RenalGenitaurinan: (document.getElementById('RenalGenitaurinan').checked),
                Allergies: (document.getElementById('Allergies').checked),
                AlcholAbuse: (document.getElementById('AlcholAbuse').checked),
                DrugAbuse: (document.getElementById('DrugAbuse').checked),
                Smoking: (document.getElementById('Smoking').checked),
                Cancer: (document.getElementById('Cancer').checked),
                Insomnia: (document.getElementById('Insomnia').checked),
                SleepApnea: (document.getElementById('SleepApnea').checked),
                Gastrointestinal: (document.getElementById('Gastrointestinal').checked),
                MajorSurgery: (document.getElementById('Surgery').checked),
                OtherInfo: (document.getElementById('someOther').value),
                
            }
        }).then(res => res.status).then((result) => {
            if (result = 200) {
                //window.location.href = '/MedicationList'
                alert('Updated')
                
            }
            else {
                //Error handling if user was unable ot save data
                prompt("internal Server Error")
            };
        }
        )}
    render() {
        return(
            <div className="medicalhistory-page">
                <Navigation/>
                <Profile />
                <div className="medical-history">
                    <div className="heading">
                        <h1> Medical History </h1> 
                    </div>
                    <form className="history-form" onSubmit={this.handleSubmit}>
                        <div className="inner-box left-check">
                                <label for="Depression">
                                    Depression <input type="checkbox" value="Depression" id="Depression" /> 
                                </label><br />

                                <label for= "NeurologicDisorder ">
                                    Neurologic Disorder <input type="checkbox" value=" NeurologicDisorder" id="NeurologicDisorder" /> 
                                </label><br />

                                
                                <label for= "HeartDisease"> 
                                    Heart Disease <input type="checkbox" value=" HeartDisease" id="HeartDisease" /> 
                                </label><br />


                                <label for= "Stroke"> 
                                    Stroke <input type="checkbox" value="Stroke " id="Stroke" />
                                </label><br />

                                
                                <label for= "HypertensiveDisorders ">  
                                    Hypertensive Disorders <input type="checkbox" value="HypertensiveDisorders" id="HypertensiveDisorders" /> 
                                </label><br />
                                
                                <label for= "RespiratoryDisease ">  
                                    Respiratory Disease<input type="checkbox" value=" RespiratoryDisease" id="RespiratoryDisease" /> 
                                </label><br />

                                <label for= "Hepatie ">
                                    Hepatie  <input type="checkbox" value="Hepatie" id="Hepatie" /> 
                                </label><br />
                                
                                <label for= "ConnectiveTissue">  
                                    Connective Tissue <input type="checkbox" value="ConnectiveTissue" id="ConnectiveTissue" /> 
                                </label><br />

                                <label for= "Musculoskeletal ">
                                    Musculoskeletal <input type="checkbox" value="Musculoskeletal" id="Musculoskeletal" /> 
                                </label><br />

                                <label for= "EndocrineMetabolic ">  
                                    Endocrine Metabolic <input type="checkbox" value="EndocrineMetabolic" id="EndocrineMetabolic" /> 
                                </label><br />

                                <label for= "HematopoieticeLymahane">  
                                    Hematopoietic Lymahane <input type="checkbox" value="HematopoieticLymahane" id="HematopoieticLymahane" /> 
                                </label><br />

                            </div>

                            <div className="inner-box right-check">

                                <label for= "RenalGenitaurinan">  Renal Genitaurinan 
                                    <input type="checkbox" value="RenalGenitaurinan " id="RenalGenitaurinan" /> 
                                </label><br />

                                <label for= "Allergies">  Allergies
                                    <input type="checkbox" value="Allergies" id="Allergies" /> 
                                 </label><br />

                                <label for= "AlcholAbuse"> Alchol Abuse 
                                    <input type="checkbox" value=" AlcholAbuse" id="AlcholAbuse" /> 
                                 </label><br />

                                <label for= "DrugAbuse"> Drug Abuse  
                                    <input type="checkbox" value="DrugAbuse" id="DrugAbuse" /> 
                                </label><br />

                                <label for= "Smoking"> Smoking
                                    <input type="checkbox" value="Smoking" id="Smoking" /> 
                                  </label><br />

                                <label for= "Cancer"> Cancer 
                                    <input type="checkbox" value="Cancer" id="Cancer" /> 
                                 </label><br />

                                <label for= "Insomnia "> Insomnia  
                                    <input type="checkbox" value="Insomnia" id="Insomnia" /> 
                                </label><br />

                                <label for= "SleepApnea ">  Sleep Apnea
                                    <input type="checkbox" value="SleepApnea" id="SleepApnea" /> 
                                </label><br />

                                <label for= "Gastrointestinal "> Gastrointestinal  
                                    <input type="checkbox" value="Gastrointestinal" id="Gastrointestinal" /> 
                                </label><br />

                                <label for= "Surgery"> 
                                    Major Surgery <input type="checkbox" value="Surgery" id="Surgery" /> 
                                </label><br />

                                <label for= "Other"> 
                                    Other: <textarea placeholder="Other" id= "someOther"> </textarea> 
                                </label><br />
                            
                            <input className="btn btn-outline-secondary btn-lg" type="submit" value="Update" style={{"width":"inherit"}}/>
                            <input type="reset" value="Reset" class="btn btn-danger btn-lg" style={{ "width": "inherit" }}></input>
                            </div> 
                    </form>
                </div>
            
            </div>
        )
    }
}
