import React, { Component } from 'react';
import "./App.css";
import Employee from './Employee';
import Rules from './Rules';
/*eslint-disable */
class Employees extends Component {
    constructor() {
        super();
        this.state = { search: '', employees: [] };
        this.Url = 'http://localhost:3002/api';
        //this.Url = 'http://localhost:58118/api';
    }

    //put put or post
    Save = (person) => {
        var action = (person.id == null) ? 'POST' : 'PUT';
        fetch(this.Url + '/People', {
            method: action,
            cache: "no-cache",
            redirect: "follow",
            referrer: "no-referrer",
            credentials: "same-origin",
            headers: {
                "Content-type": "application/json; charset=UTF-8",
                "id": person.id,
            },
            body: JSON.stringify(person)
        }).then(response => {
            this.setState({ status: 'saved' });
            setTimeout(() => { this.setState({ status: null }) }, 5000);
        })
    }

    //create employee
    Create = () => {
        //this will create a race condition that causes new employees not to show totals.  in real world I would reload this from a server.
        this.state.employees.push({ firstName: 'New', lastName: 'Employee', dependents: [] });
        this.setState((state) => ({ employees: state.employees }));
    }

    //delete employee
    Delete = (person) => {
        if (!isNaN(person.id)) {
            let p = person;
            fetch(this.Url + '/People/' + person.id, {
                method: 'Delete',
                cache: "no-cache",
                redirect: "follow",
                referrer: "no-referrer",
                credentials: "same-origin",
                headers: {
                    "Content-type": "application/json; charset=UTF-8",
                    "id": person.id,
                }
            }).then(response => {
                var temp = this.state.employees;
                temp.splice(temp.indexOf(p), 1);
                this.setState({ employees: [], status: 'deleted' });
                setTimeout(() => { this.setState({ employees:temp }) }, 0);
                setTimeout(() => { this.setState({ status: null }) }, 5000);
            });
        }
        else {
            this.Get();
        }
    }

    Search = () => {
        debugger;
        fetch(this.Url + '/People/' + this.state.search, {
            method: 'GET',
            cache: "no-cache",
            redirect: "follow",
            referrer: "no-referrer",
            credentials: "same-origin",
            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        }).then(response => {
            return response.json();
        }).then(people => {
            this.setState({ employees: people })
        });
    }

    //this gets all employees.  Obviously in real life we would not do that on loan: paging or lazy loading or combination thereof would work
    Get = () => {
        fetch(this.Url + '/People', {
            method: 'GET',
            cache: "no-cache",
            redirect: "follow",
            referrer: "no-referrer",
            credentials: "same-origin",
            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        }).then(response => {
            return response.json();
            }).then(people => {
                this.setState({ employees: people })
            });
    }

    HandleSearch = (e) => {
        let search = e.target.value;
        this.setState(() => ({ search: search }));
    }

    render() {
        if (this.state.employees.length == 0) {
            this.Get();
        }
      return (
          <div className="Employees">
              <div className="Top" value={this.state.search} onChange={this.HandleSearch.bind(this)}><input /><button onClick={this.Search.bind(this)} className="Go">GO</button></div>
              <div className="Status">{this.state.status}</div>
              <ul>
                  {this.state.employees.map(employee => {
                      return <li>
                          <Employee employee={employee} saveCallback={this.Save} deleteCallback={this.Delete}></Employee>
                          <Rules id={employee.id}></Rules>
                      </li>
                  })}
                  <div><button onClick={this.Create}>+</button></div>
              </ul>
        </div>
    );
  }
}

export default Employees;
