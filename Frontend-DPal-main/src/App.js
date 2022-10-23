import './App.css';
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link
} from "react-router-dom";
import Landing from './pages/LandingPage';
import Login from './pages/LoginPage';
import Signup from './pages/SignUpPage';
import Profile from './pages/ProfilePage';
import Medication from './pages/MedicationList';
import History from './pages/MedicalHistory';
import BehaviourTracker from './pages/BehaviourTracker';
import ProtectedRoute from './ProtectedRoute';
import Caregiver from './pages/CareGiver';
import CarePlan from './pages/BehaviourCarePlan';
import GetHelp from './pages/GetHelp';



function App() {
  return (
    <Router>
      <Routes>
        <Route path='/' element={<Landing />} />
        <Route path='/Login' element={<Login />} />
        <Route path='/Signup' element={<Signup />} />
        <Route element={<ProtectedRoute/>}>
          <Route path="/Profile" element={<Profile />} />
          <Route path='/MedicationList' element={<Medication />}/>
          <Route path='/History' element={<History />}/>
          <Route path='/BehaviourTracker' element={<BehaviourTracker />}/>
          <Route path='/Caregiver' element={<Caregiver />} />
          <Route path='/Careplan' element={<CarePlan />} />
          <Route path='/GetHelp' element={<GetHelp />} />
        </Route>
      </Routes>
    </Router>
  );
}

export default App;
