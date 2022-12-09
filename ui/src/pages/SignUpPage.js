import { Component, forwardRef } from "react";
import Navigation from "../components/navigation";
import '../styles/SignupPage.css';




// render signup page when signup is clicked 
class Signup extends Component {
    constructor(props) {
    super(props);
    this.state = {value: ''};
    
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  //check passwords to make sure they are equal before submitting form
  async handleSubmit(event) {
    if (document.getElementById('password').value == document.getElementById('confirmPassword').value){
        let myAddress = document.getElementById('address1').value + document.getElementById('address2').value + " "+
                        document.getElementById('country').value + " "+ document.getElementById('city').value  + " "+
                        document.getElementById('province/state').value +  " " +
                        document.getElementById('postal/zip').value ;

        let myEmail = document.getElementById('email').value;
        myEmail = myEmail.toLowerCase();
        
        // fetch request to save user info to database
        fetch(process.env.REACT_APP_API+'registerusers',
            {
                method : 'POST',
                headers:{
                'Accept': 'application/json',
                'Content-Type' : 'application/json'
                //URLSearchParams: 
            },
            body : JSON.stringify(
                {
                    //get values from input fields
                    firstName :document.getElementById('firstName').value,
                    lastName : document.getElementById('lastName').value,
                    emailAdd : myEmail,
                    password : document.getElementById('password').value,
                    sex : document.getElementById('sex').value,
                    phoneNum : document.getElementById('phone').value,
                    address : myAddress ,
                    termCon:  true

                })
            }).then((res=>res.status)).then((result)=>{
                if(result ==200){
                    //successful signups lead back to login page after prompt
                    alert('Account Created')
                    window.location.href = '/Login';

                }
                // Error handling if signup was not successful
                else{prompt("internal Error Please Try Again")}
            },(error) =>{
                alert(error);
                
             })
        event.preventDefault();}
        else{
            //Alert user if passwords do not match
            alert("Passwords do not match");
            event.preventDefault();
        }

    }
    //render signup page
    render() {

        return(
            <div>
                <Navigation />
                <div className="signup-form">
                    <form onSubmit={this.handleSubmit}>
                        <fieldset>
                            <legend>Sign Up</legend>
                            <div className="left-side">
                                <label for='firstName'>First Name *</label><br/>
                                <input type='text' id='firstName' required/><br/>
                                <label for='lastName'>Last Name *</label><br/>
                                <input type='lastName' id='lastName' required/><br />
                                <label for='email'>Email *</label><br />
                                <input type='email' id='email' required/><br />
                                <label for='password'  >Password *</label><br />
                                <input type='password' id='password' required placeholder="Password" minLength = "8"/><br />
                                <label for='confirmPassword'>Confirm Password *</label><br />
                                <input type='password' id='confirmPassword' required autoComplete="on"/><br />
                                <label for='sex'>Sex *</label><br/>
                                <select id="sex" name="sex" required>
                                    <option value="male">Male</option>
                                    <option value="female">Female</option>
                                    <option value="other">Other/Prefer not to say</option>
                                </select><br/>
                                <label for="phone">Phone Number *</label>
                                <input type="tel" id="phone" name="phone" placeholder="eg. 1123456789" required ></input><br/>
                                
                            </div>
                            <div className="right-side">
                                <label for='address1'>Street Address *</label><br/>
                                <input type='text' id='address1' required/><br/>
                                <label for='address2'>Street Address 2</label><br/>
                                <input type='text' id='address2'/><br/>
                                <label for='country'>Country *</label><br/>
                                <input type='text' id='country' required/><br/>
                                <label for='city'>City *</label><br/>
                                <input type='text' id='city' required/><br/>
                                <label for='province/state'>Province/State *</label><br/>
                                <input type='text' id='province/state' required/><br/>
                                <label for='postal/zip'>Postal/Zip Code *</label><br/>
                                <input type='text' id='postal/zip' required/><br/>
                                <input type="checkbox" value="agree" id="terms/condition" required /> 
                                <label for="terms/condition">I agree to the Terms and Conditions *</label><br />
                            </div>
                            
                            <input type="submit" value="Signup" />
                            <input type="reset" value="Reset"></input>
                        </fieldset>
                    </form>
                </div>
            </div>

            
        )
    }
}
export default Signup;