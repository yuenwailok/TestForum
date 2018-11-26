"use strict";

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var record = {
    "id": "3",
    "start_date": "2018-02-16",
    "end_date": "2200-12-15",
    "rent": 820,
    "frequency": "weekly",
    "payment_day": "friday"
};

var day = Object.freeze({
    "monday": 0,
    "tuesday": 1,
    "wednesday": 2,
    "thursday": 3,
    "friday": 4,
    "saturday": 5,
    "sunday": 6
});

//console.log(recordList(record));

function recordList(record) {
    var recordlist = [];
    var startdate = parseDate(record.start_date);
    var enddate = parseDate(record.end_date);
    Object.freeze(record);
    for (var i = new Date(startdate); i <= enddate; i.setDate(i.getDate() + 1)) {
        if (i.getDay() == day[record.payment_day]) {
            recordlist.push([startdate, new Date(i)]);
            i.setDate(i.getDate() + 1);
            startdate = new Date(i);
            if (record.frequency === "fortnightly") {
                i.setDate(i.getDate() + 12);
            } else if (record.frequency === "weekly") {
                i.setDate(i.getDate() + 5);
            } else if (record.frequency === "monthly") {
                i.setDate(i.getDate() + 26);
            }
        }
    }

    if (startdate <= enddate) recordlist.push([startdate, enddate]);

    for (var _i = 0; _i < recordlist.length; _i++) {
        var days = daysBetween(recordlist[_i][0], recordlist[_i][1]) + 1;
        recordlist[_i].push(days, "$" + (record.rent / 7 * days).toFixed(1));
    }
    return recordlist;
}

function treatAsUTC(date) {
    var result = new Date(date);
    result.setMinutes(result.getMinutes() - result.getTimezoneOffset());
    return result;
}

function daysBetween(startDate, endDate) {
    var millisecondsPerDay = 24 * 60 * 60 * 1000;
    return (treatAsUTC(endDate) - treatAsUTC(startDate)) / millisecondsPerDay;
}
function parseDate(input) {
    var parts = input.split('-');
    // new Date(year, month [, day [, hours[, minutes[, seconds[, ms]]]]])
    return new Date(parts[0], parts[1] - 1, parts[2]); // Note: months are 0-based
}

function displayDate(date) {
    if (date instanceof Date) {
        return date.toDateString();
    }
    return date.toString();
}

function SummaryTable(props) {
    console.log(props instanceof Date);
    var para = [];
    try {
        para = Object.getOwnPropertyNames(props.obj).map(function (item, index) {
            return React.createElement(
                "tr",
                { key: index },
                React.createElement(
                    "td",
                    { key: item + "" + index },
                    item.replace('_', '-')
                ),
                React.createElement(
                    "td",
                    { key: props.obj[item] + "" + index },
                    props.obj[item]
                )
            );
        });
    } catch (err) {
        return React.createElement(
            "p",
            null,
            "Something bad happened that makes the system cannot display the lease's summary"
        );
    }

    return React.createElement(
        "div",
        null,
        React.createElement(
            "p",
            null,
            "This is the summary of the lease"
        ),
        React.createElement(
            "table",
            { border: "1 px solid" },
            React.createElement(
                "tbody",
                null,
                para
            )
        )
    );
}

function PaymentTable(props) {
    var table = [];
    try {
        table = props.record.map(function (item1, index1) {
            return React.createElement(
                "tr",
                { key: index1 },
                item1.map(function (item2, index2) {
                    return React.createElement(
                        "td",
                        { key: index1 + "" + index2 },
                        displayDate(item2)
                    );
                })
            );
        });
    } catch (err) {
        return React.createElement(
            "p",
            null,
            "Something goes wrong when the system display the payments"
        );
    }

    return React.createElement(
        "div",
        null,
        React.createElement(
            "p",
            null,
            "These are the payments of your lease"
        ),
        React.createElement(
            "table",
            { border: "1" },
            React.createElement(
                "tbody",
                null,
                React.createElement(
                    "tr",
                    null,
                    React.createElement(
                        "th",
                        null,
                        "From"
                    ),
                    React.createElement(
                        "th",
                        null,
                        "To"
                    ),
                    React.createElement(
                        "th",
                        null,
                        "Days"
                    ),
                    React.createElement(
                        "th",
                        null,
                        "Amount"
                    )
                ),
                table
            )
        )
    );
}

function DisplayTable(props) {
    try {
        if (props.record.length != 0) {
            return React.createElement(
                "div",
                null,
                React.createElement(SummaryTable, { obj: props.obj }),
                React.createElement(PaymentTable, { record: props.record })
            );
        }
        return null;
    } catch (err) {
        return null;
    }
}

function InputForms(props) {
    return React.createElement(
        "form",
        { onSubmit: props.handleSubmit },
        React.createElement(
            "label",
            null,
            "Lease id:",
            React.createElement("input", { type: "text", value: props.value, onChange: props.handleChange, required: true, pattern: "[a-zA-Z0-9]+", maxLength: "8" })
        ),
        React.createElement("input", { type: "submit", value: "Submit" })
    );
}

function isValidate(input) {
    return input.match(/\W/) === null && input.length != 0 && input.length <= 8;
}

var DisplayRecord = function (_React$Component) {
    _inherits(DisplayRecord, _React$Component);

    function DisplayRecord(props) {
        _classCallCheck(this, DisplayRecord);

        var _this = _possibleConstructorReturn(this, (DisplayRecord.__proto__ || Object.getPrototypeOf(DisplayRecord)).call(this, props));

        _this.state = {
            value: '',
            records: [],
            records2: {},
            error: false
        };

        _this.handleChange = _this.handleChange.bind(_this);
        _this.handleSubmit = _this.handleSubmit.bind(_this);
        return _this;
    }

    _createClass(DisplayRecord, [{
        key: "componentDidCatch",
        value: function componentDidCatch(caughterror) {
            this.setState({ error: true });
        }
    }, {
        key: "handleChange",
        value: function handleChange(event) {
            this.setState({ value: event.target.value });
        }
    }, {
        key: "handleSubmit",
        value: function handleSubmit(event) {
            var _this2 = this;

            fetch('https://hiring-task-api.herokuapp.com/v1/leases/' + this.state.value).then(function (response) {
                if (response.ok && isValidate(_this2.state.value)) {
                    return response.json();
                } else {
                    throw new Error('The system cannot found the lease record according to the id you have entered.');
                }
            }).then(function (data) {

                _this2.setState({ records: recordList(data), records2: data, error: false });
            }).catch(function (error) {
                _this2.setState({ error: true });
            });

            event.preventDefault();
        }
    }, {
        key: "render",
        value: function render() {
            if (this.state.error) {
                return React.createElement(
                    "div",
                    null,
                    React.createElement(InputForms, { handleSubmit: this.handleSubmit, value: this.state.value, handleChange: this.handleChange }),
                    React.createElement(
                        "p",
                        null,
                        "Sorry, we cannot search for the lease record according to the id you have entered"
                    )
                );
            } else {
                return React.createElement(
                    "div",
                    null,
                    React.createElement(InputForms, { handleSubmit: this.handleSubmit, value: this.state.value, handleChange: this.handleChange }),
                    React.createElement(DisplayTable, { record: this.state.records, obj: this.state.records2 })
                );
            }
        }
    }]);

    return DisplayRecord;
}(React.Component);

ReactDOM.render(React.createElement(DisplayRecord, null), document.getElementById('root'));