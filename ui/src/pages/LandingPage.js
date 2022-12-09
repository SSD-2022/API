import { Component } from "react";
import Navigation from '../components/navigation/index.js';
import Slideshow from '../components/slideshow/index.js';
import LandingGrid from '../components/landing-page-grid';

//render landing page
class Landing extends Component {
    render() {
        return ( 
            <div>
                <Navigation />
                <Slideshow />
                <LandingGrid />
            </div>
        )
    }
}

export default Landing;