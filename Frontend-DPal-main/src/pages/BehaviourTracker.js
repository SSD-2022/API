import { Component, Profiler ,useState,useEffect} from "react";
import Navigation from "../components/navigation";
import Profile from "../components/profiler";
import Slider from '@mui/material/Slider';
import '../styles/BehaviourTracker.css';
import { Button } from "bootstrap";
import React from "react";
import { getAllByPlaceholderText } from "@testing-library/react";
import Cookies from 'js-cookie'
import CircleLoader from "react-spinners/CircleLoader";





export default function BehaviourTracker(){

    //animation set on page load
    const [loading4, setLoading4] = useState(false);

    useEffect(() =>{
        setLoading4(true)
        setTimeout(() =>{
            setLoading4(false)

        },2000)
    },[])
    return (
        <div className="loadAnimate">
            {
                loading4 ? <div className="loadCenter"><CircleLoader size = {200} color = {"#D0021B"}
                loading4 = {loading4}/></div>
                :<BTracker/>
            }</div>
    )
}



function BTracker() {

    //set initial values for fields
    const [val1,setValue1] = useState(0)
    const [val2,setValue2] = useState(0)
    const [val3,setValue3] = useState(0)
    const [val4,setValue4] = useState(0)
    const [val5,setValue5] = useState(0)
    const [val6,setValue6] = useState(0)
    const [val7,setValue7] = useState(0)
    const [val8,setValue8] = useState(0)
    const [val9,setValue9] = useState(0)
    const [val10,setValue10] = useState(0)
    const [val11,setValue11] = useState(0)
    const [val12,setValue12] = useState(0)
    const [val13,setValue13] = useState(0)
    const [val14,setValue14] = useState(0)
    const [val15,setValue15] = useState(0)
    const [val16,setValue16] = useState(0)

    //update values on slider drag
    const handleUpdate1 = (event,newValue)=> {
        setValue1(newValue)
        console.log("val 1 : "+val1)}

    const handleUpdate2 = (event,newValue)=> {
        setValue2(newValue)
        console.log("val 2 : "+val2)}

        const handleUpdate3 = (event,newValue)=> {
        setValue3(newValue)
        console.log("val 3 : "+val3)}

        const handleUpdate4 = (event,newValue)=> {
        setValue4(newValue)
        console.log("val 4 : "+val4)}

        const handleUpdate5 = (event,newValue)=> {
        setValue5(newValue)
        console.log("val 5 : "+val5)}

        const handleUpdate6 = (event,newValue)=> {
        setValue6(newValue)
        console.log("val 6 : "+val6)}

        const handleUpdate7 = (event,newValue)=> {
        setValue7(newValue)
        console.log("val 7 : "+val7)}

        const handleUpdate8 = (event,newValue)=> {
        setValue8(newValue)
        console.log("val 8 : "+val8)}

        const handleUpdate9 = (event,newValue)=> {
        setValue9(newValue)
        console.log("val 9 : "+val9)}

        const handleUpdate10 = (event,newValue)=> {
        setValue10(newValue)
        console.log("val 10 : "+val10)}

        const handleUpdate11 = (event,newValue)=> {
        setValue11(newValue)
        console.log("val 11 : "+val11)}

        const handleUpdate12 = (event,newValue)=> {
        setValue12(newValue)
        console.log("val 12 : "+val12)}

        const handleUpdate13 = (event,newValue)=> {
        setValue13(newValue)
        console.log("val 13 : "+val13)}

        const handleUpdate14 = (event,newValue)=> {
        setValue14(newValue)
        console.log("val 14 : "+val14)}

        const handleUpdate15 = (event,newValue)=> {
        setValue15(newValue)
        console.log("val 15 : "+val15)}

        const handleUpdate16 = (event,newValue)=> {
        setValue16(newValue)
        console.log("val 16 : "+val16)}

        function SaveIt() {
            let email = Cookies.get('name')
            fetch(process.env.REACT_APP_API+'behaviourtrackers',
            {   //URLSearchParams: 
                method : 'POST',
                headers:{
                'Accept': 'application/json',
                'Content-Type' : 'application/json'
                },
            body : JSON.stringify(
                //assign fields to a value 
                {   emailAdd : email, agression: val1, Agitation   : val2, Apathy  :val3, EatingProblems  : val4,
                    ExcessiveCollecting : val5, ExcessiveOrganizing : val6, ImaginingThings : val7, Impulsiveness   : val8,
                    Incontinence    : val9, Repetition  : val10, ResistancetoCare    : val11, Restlessness    :val12,
                    SafetyConcerns  : val13, Sleeping    : val14, Suspicion   :val15, Wandering   : val16

                })
                }).then(res=>res.status).then( (result) => {
                    if (result == 200){
                        
                        //set cookies for each of the sliders to hold information
                        Cookies.set('Aggression',val1 , { expires:7})
                        Cookies.set('Agitation',val2 , { expires:7})
                        Cookies.set('Apathy',val3 , { expires:7})
                        Cookies.set('EatingProblem',val4 , { expires:7})
                        Cookies.set('Collecting',val5 , { expires:7})
                        Cookies.set('Organizing',val6 , { expires:7})
                        Cookies.set('Imagining',val7 , { expires:7})
                        Cookies.set('Impulsiveness',val8 , { expires:7})
                        Cookies.set('Incontinence',val9 , { expires:7})
                        Cookies.set('Repetition',val10 , { expires:7})
                        Cookies.set('Resistance',val11 , { expires:7})
                        Cookies.set('Restlessness',val12 , { expires:7})
                        Cookies.set('Safety',val13 , { expires:7})
                        Cookies.set('Sleeping',val14 , { expires:7})
                        Cookies.set('Suspicion',val15 , { expires:7})
                        Cookies.set('Wandering',val16 , { expires:7})
                        window.location.href = '/Careplan';
                }
                else{
                    alert("internal Server Error!! Please try Again")
                }
            },(error) =>{
                console.log(error);
                alert('failed')
             })
        }

        return(
            <div className="behaviour-tracker">
                <Navigation />
                <Profile />
                <div className="tracker">
                    <div className="inside-trackers left-tracker">
                        <label className="label" for="Aggression">Aggression</label>
                        <div className="slider">
                        <Slider value = {val1} onChange = {handleUpdate1}
                            aria-label="aggression"
                            defaultValue={0}
                            valueLabelDisplay="auto"
                            step={1}
                            marks
                            min={0}
                            max={10}
                            />
                        </div><br />

                        <label className="label" for="Agitation">Agitation/Irritableness</label>
                        <div className="slider">
                        <Slider value = {val2} onChange = {handleUpdate2}
                            aria-label="agitation"
                            defaultValue={0}
                            valueLabelDisplay="auto"
                            step={1}
                            marks
                            min={0}
                            max={10}
                            />
                        </div><br />

                        <label className="label" for="Apathy">Apathy</label>
                        <div className="slider">
                            <Slider value = {val3} onChange = {handleUpdate3}
                                aria-label="apathy"
                                defaultValue={0}
                                valueLabelDisplay="auto"
                                step={1}
                                marks
                                min={0}
                                max={10}
                                />
                        </div><br />

                        <label className="label" for="eating">Eating Problems</label>
                        <div className="slider">
                            <Slider value = {val4} onChange = {handleUpdate4}
                                aria-label="eating"
                                defaultValue={0}
                                valueLabelDisplay="auto"
                                step={1}
                                marks
                                min={0}
                                max={10}
                                />
                        </div><br />

                        <label className="label" for="collecting">Excessive Collecting</label>
                        <div className="slider">
                            <Slider value = {val5} onChange = {handleUpdate5}
                                aria-label="collecting"
                                defaultValue={0}
                                valueLabelDisplay="auto"
                                step={1}
                                marks
                                min={0}
                                max={10}
                                />
                        </div><br />

                        <label className="label" for="oragnizing">Excessive Organizing</label>
                        <div className="slider">
                            <Slider value = {val6} onChange = {handleUpdate6}
                                aria-label="organizing"
                                defaultValue={0}
                                valueLabelDisplay="auto"
                                step={1}
                                marks
                                min={0}
                                max={10}
                                />
                        </div><br />

                        <label className="label" for="imagining">Imagining Things</label>
                        <div className="slider">
                            <Slider value = {val7} onChange = {handleUpdate7}
                                aria-label="imagining"
                                defaultValue={0}
                                valueLabelDisplay="auto"
                                step={1}
                                marks
                                min={0}
                                max={10}
                                />
                        </div><br />

                        <label className="label" for="impulsiveness">Impulsiveness</label>
                        <div className="slider">
                            <Slider value = {val8} onChange = {handleUpdate8}
                                aria-label="impulsiveness"
                                defaultValue={0}
                                valueLabelDisplay="auto"
                                step={1}
                                marks
                                min={0}
                                max={10}
                                />
                        </div><br />
                        
                    </div>
                    <div className="inside-trackers right-tracker">

                        <label className="label" for="incontinence">Incontinence</label>
                        <div className="slider">
                        <Slider value = {val9} onChange = {handleUpdate9}
                            aria-label="incontinence"
                            defaultValue={0}
                            valueLabelDisplay="auto"
                            step={1}
                            marks
                            min={0}
                            max={10}
                            />
                        </div><br />

                        <label className="label" for="repetition">Repetition</label>
                        <div className="slider">
                        <Slider value = {val10} onChange = {handleUpdate10}
                            aria-label="repetition"
                            defaultValue={0}
                            valueLabelDisplay="auto"
                            step={1}
                            marks
                            min={0}
                            max={10}
                            />
                        </div><br />

                        <label className="label" for="resistance">Resistance to Care</label>
                        <div className="slider">
                        <Slider value = {val11} onChange = {handleUpdate11}
                            aria-label="resistance"
                            defaultValue={0}
                            valueLabelDisplay="auto"
                            step={1}
                            marks
                            min={0}
                            max={10}
                            />
                        </div><br />

                        <label className="label" for="restlessness">Restlessness</label>
                        <div className="slider">
                        <Slider value = {val12} onChange = {handleUpdate12}
                            aria-label="restlessness"
                            defaultValue={0}
                            valueLabelDisplay="auto"
                            step={1}
                            marks
                            min={0}
                            max={10}
                            />
                        </div><br />

                        <label className="label" for="safety">Safety Concerns</label>
                        <div className="slider">
                        <Slider value = {val13} onChange = {handleUpdate13}
                            aria-label="safety"
                            defaultValue={0}
                            valueLabelDisplay="auto"
                            step={1}
                            marks
                            min={0}
                            max={10}
                            />
                        </div><br />

                        <label className="label" for="sleep">Sleeping</label>
                        <div className="slider">
                        <Slider value = {val14} onChange = {handleUpdate14}
                            aria-label="sleep"
                            defaultValue={0}
                            valueLabelDisplay="auto"
                            step={1}
                            marks
                            min={0}
                            max={10}
                            />
                        </div><br />

                        <label className="label" for="paranoia">Suspicion/Paranoia</label>
                        <div className="slider">
                        <Slider value = {val15} onChange = {handleUpdate15}
                            aria-label="paranoia"
                            defaultValue={0}
                            valueLabelDisplay="auto"
                            step={1}
                            marks
                            min={0}
                            max={10}
                            />
                        </div><br />

                        <label className="label" for="wandering">Wandering</label>
                        <div className="slider">
                        <Slider value = {val16} onChange = {handleUpdate16}
                            aria-label="wandering"
                            defaultValue={0}
                            valueLabelDisplay="auto"
                            step={1}
                            marks
                            min={0}
                            max={10}
                            />
                        </div><br />
                        
                    </div>
                    <button className="btn btn-outline-secondary" onClick = {SaveIt} >Update</button>
                </div>
                
                    
            </div>
        )
    }
