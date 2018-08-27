import React, { Component } from 'react';
import Person from './Person';
import "./App.css";
/*eslint-disable */
class Employee extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <div className="Employee">
                <Person person={this.props.employee} saveCallback={this.props.saveCallback} deleteCallback={this.props.deleteCallback}></Person>
                <ul>
                    {this.props.employee.dependents.map(dependent => <li><Person person={dependent}></Person></li>)}
                </ul>
            </div>
        );
    }
}

export default Employee;
