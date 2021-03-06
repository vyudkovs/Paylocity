import React, { Component } from 'react';
/*eslint-disable */
class Rules extends Component {
    constructor(props) {
        super(props);
        this.state = { rule: [] }
        fetch('http://localhost:3002/api/rules/' + this.props.id, {
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
        }).then(r => {
            this.setState({ rule: r });
        });
    }

    ShowRules(rules) {
        let result = [];
        for (let i = 0; i < rules.length; i++) {
            result.push(<div>{rules[i].name} {'$' + rules[i].subtotal.toFixed(2)}</div>);
        }
        return result;
    }
    render() {
        return (
            <div className="Rule">
                {this.ShowRules(this.state.rule.items||[])}
                Check amount <b>${(this.state.rule.total || 0).toFixed(2)}</b>
            </div>
        );
    }
}

export default Rules;
