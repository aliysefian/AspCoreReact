import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from "axios";
// import {IActivty} from '../src/app/models/activity';



class App extends Component {
   state={
    activities:[]
  }
  componentDidMount(){
    axios.get("http://localhost:5000/api/activity").then((response=>{
      console.log(response);
      this.setState({activities:response.data});
      
    }))

  }
  render() {
    return (
      <div className="App">
        <div className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h2>Welcome to React</h2>
        </div>
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
        </p>
        <div>
          {this.state.activities.map(m=>(<div key={m.id}>
            {m.title}
          </div>
          ))}
        </div>
      </div>
    );
  }
}

export default App;
