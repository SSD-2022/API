import { Component } from "react";
import Navigation from "../components/navigation";
import Profiler from "../components/profiler";
import '../styles/BehaviourCarePlan.css';
import Cookies from 'js-cookie';
import BarLoader from "react-spinners/BarLoader";
import {useState, useEffect } from "react"; 




export default function BehaviourCarePlan() {
    
    //animation on page load
    const [loading11, setLoading11] = useState(false);

    useEffect(() => {
        setLoading11(true)
        setTimeout(() => {
            setLoading11(false)

        }, 2000)
    }, [])
    return (
        <div className="loadAnimate">
            {
                loading11 ? <div className="loadCenter"><BarLoader height={30} width={100} color={"#BD10E0"}
                    loading11={loading11} /></div>
                    : <CarePlan />
            }</div>
    )
}



const items = []

//Check to see if user has used the slider in behaviour tracker before listing items
function checkCookie(){

    items.push({ title: 'Behaviour Management', plan: 
    'Behavior management, similar to behavior modification, is a less-intensive form of behavior therapy. Unlike behavior modification, which focuses on changing behavior, behavior management focuses on maintaining positive habits and behaviors and reducing negative ones. Behavior management skills are especially useful for teachers and educators, healthcare workers, and those working in supported living communities.This form of management aims to help professionals oversee and guide behavior management in individuals and groups toward fulfilling, productive, and socially acceptable behaviors. Behavior management can be accomplished through modeling, rewards, or punishment.'})

}



class CarePlan extends Component {
    constructor(props) {
        super(props);
    }

    //when component mounts, run initial functions before render
    componentDidMount() {
        checkCookie();
      }


    render() {

        //map list items into p tags to display on page

        const listItems = items.map((item) =>
            
            <div class="jumbotron" style={{"margin-bottom": "10px"}}>
                <h4 class="display-4">{item.title}</h4>
                <p class="lead">{item.plan}</p>
                <hr class="my-4"/>
                <p>Recognize that defensive behavior is normal, as "defensive behaviors are intended to reduce a perceive threat or avoid an unwanted threat," It is normal for one to be defensive when they feel that something is their fault. These actions are attempted in order to avoid blame or change of action.</p>
                <p>Never attack a person's defenses. Do not try to “explain someone” to themselves by saying things like, “you know the real reason you are using that excuse is that you cannot bear to be blamed for anything.” Instead, try to concentrate on the act itself rather than on the person.</p>
                <p>Recognize human limitations. Do not expect to be able to solve every problem that comes up, especially the human ones. More importantly, remember that a layman should not try to be a psychologist.</p>
                <a class="btn btn-primary btn-lg" target="_blank" href="https://en.wikipedia.org/wiki/Behavior_management" role="button">Learn more</a>
            </div>
            )
        return(
            <div className="careplan-page">
                <Navigation/>
                <Profiler />

                
                <div className="careplan">
                    <div className="heading">
                        <h2>Behaviour Care Plan</h2>
                    </div>

                    <div class="container">

                        <div class="row gx-5">
                            {listItems}
                        </div>
                    </div>
                    
                </div>

            </div>
        )
    }
}

