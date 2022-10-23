import 'bootstrap/dist/css/bootstrap.min.css';
import {Component} from 'react';
import img1 from './images/gethelp1.png';
import img2 from './images/gethelp2.png';
import img3 from './images/gethelp3.png';
import Navigation from '../components/navigation';
import '../styles/GetHelp.css';

//render get help page
class GetHelp extends Component {
    render() {
        return(
            <div className='gethelp-page'>
                <Navigation />
                <div class="get-help-container">
                    <div class="card" style={{ margin: "10px" }}>
                    <img src={img1} class="card-img-top" alt="Dementia_photo"></img>
                        <div class="card-body" className='get-help-container-card-body'>
                            <h5 class="card-title">Alzheimer's Association</h5>
                            <p class="card-text">The Alzheimer's Association leads the way to end Alzheimer's and all other dementia.</p>
                            <a href="https://www.alz.org/" target='_blank' class="btn btn-primary">Click Here</a>
                        </div>
                    </div>

                    <div class="card" style={{margin: "10px"}}>
                    <img src={img2} class="card-img-top" alt="Dementia_photo2"></img>
                        <div class="card-body" className='get-help-container-card-body'>
                            <h5 class="card-title">DementiaUK</h5>
                            <p class="card-text">We are Dementia UK – the specialist dementia nurse charity.</p>
                            <a href="https://www.dementiauk.org/" target='_blank' class="btn btn-primary">Click Here</a>
                        </div>
                    </div>

                    <div class="card" style={{ margin: "10px" }}>
                    <img src={img3} class="card-img-top" alt="Dementia_photo3"></img>
                        <div class="card-body" className='get-help-container-card-body'>
                            <h5 class="card-title">WHO</h5>
                            <p class="card-text">A global presence that puts countries at the centre of our work</p>
                            <a href="https://www.who.int/news-room/fact-sheets/detail/dementia" target='_blank' class="btn btn-primary">Click Here</a>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}  
export default GetHelp; 