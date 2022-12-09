import { Component } from "react";
import { Carousel } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import './slideshow.css';

//slideshow using carousel from bootstrap
class Slideshow extends Component {
    render(){
        return(
            <div className="carousel">
                <Carousel>
                    <Carousel.Item>
                        <img
                        className="d-block w-100"
                            src="https://api.benefits.gov/sites/default/files/styles/crop_image_style_16_9/public/2020-08/bWa5yiO%20-%20Imgur_0.jpg?h=08de3a47&itok=kktXAi09"
                        alt="First slide"
                        />
                        <Carousel.Caption>
                            <h3>First slide label</h3>
                            <p>PlaceHolder Text</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img
                        className="d-block w-100"
                            src="https://www.bayshore.ca/wp-content/uploads/2020/04/Pathway-to-Health-April-2020-prescriptions-photo.jpg"
                        alt="Second slide"
                        />

                        <Carousel.Caption>
                        <h3>Second slide label</h3>
                        <p>PlaceHolder Text</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img
                        className="d-block w-100"
                            src="https://api.benefits.gov/sites/default/files/styles/crop_image_style_16_9/public/2022-03/Volunteers_0.jpeg?h=48dbacce&itok=RKaW3oHI"
                        alt="Third slide"
                        />

                        <Carousel.Caption>
                        <h3>Third slide label</h3>
                        <p>PlaceHolder Text</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                </Carousel>
            </div>
        )
    }
}

export default Slideshow;