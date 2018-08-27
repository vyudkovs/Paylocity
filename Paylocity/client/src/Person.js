import React, { Component } from 'react';
import "./App.css";
/*eslint-disable */
class Employee extends Component {
    constructor(props) {
        super(props);
        this.state = { person: props.person, isHiddenWritable: true }
    }
    handleClick = () => {
        this.setState((state, props) => ({ isHiddenWritable: !state.isHiddenWritable }));
    };
    handleSave = () => {
        this.setState((state, props) => ({ isHiddenWritable: !state.isHiddenWritable }));
        this.props.saveCallback(this.state.person)
    };
    handleDelete = () => {
        this.props.deleteCallback(this.state.person);
    };
    handleName = function(e) {
        var person = this.state.person;
        person[e.target.name] = e.target.value;
        this.setState({ person: person });
    };
    render() {
        return (
            <div className="Person">
                <span onClick={this.handleClick.bind(this)}>{this.state.person.firstName} {this.state.person.lastName}</span>
                {!this.state.isHiddenWritable &&
                    <div>
                    <input name="firstName" value={this.state.person.firstName} onChange={this.handleName.bind(this)} />
                    <input name="lastName" value={this.state.person.lastName} onChange={this.handleName.bind(this)} />
                    {this.state.person.dependents != undefined && <input type='button' value='save' onClick={this.handleSave.bind(this)} />}
                    {this.state.person.dependents != undefined && <input type='button' value='x' onClick={this.handleDelete.bind(this)} />}
                    </div>
                }
            </div>
        );
    }
}

export default Employee;
