import {Component} from 'react';
import { Navbar, Nav, NavDropdown, Container } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import './navigation.css';
import Auth from '../../Auth';

//render navigation bar
class Navigation extends Component {
    render() {
        return(
            <div>
            <Navbar class="navbar navbar-light" style={{ "background-color": "#dee2e6"}} expand="lg" >
                <Container>
                  <Navbar.Brand href="/">Dementia Pal</Navbar.Brand>
                  <Navbar.Toggle aria-controls="basic-navbar-nav" />
                  <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                      <Nav.Link href="Profile">My Profile</Nav.Link>
                      <Nav.Link href="GetHelp">Get Help</Nav.Link>
                      <NavDropdown title="Let's Talk" id="basic-nav-dropdown">
                        <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
                        <NavDropdown.Item href="#action/3.2">Another action</NavDropdown.Item>
                        <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
                        <NavDropdown.Divider />
                        <NavDropdown.Item href="#action/3.4">Separated link</NavDropdown.Item>
                      </NavDropdown>

                    </Nav>
                  </Navbar.Collapse>
                  
                </Container>
                
              </Navbar>
            </div>
        )
    }
}

export default Navigation;