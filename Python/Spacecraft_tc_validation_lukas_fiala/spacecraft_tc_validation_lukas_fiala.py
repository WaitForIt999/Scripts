import sys


def telecommand():
    return {
        "command_id": (20, 129),
        "logical_device_id": 0x05,
        "parameter_id": 42,
        "ack_start": True,
    }

tc = telecommand()


# Check logical device ID
if not (0x03 <= tc["logical_device_id"] <= 0x3F):
    print("TM(1,4): INVALID_LOGICAL_DEVICE_ID")
    sys.exit(1)

# Check parameter ID
elif not (1 <= tc["parameter_id"] <= 157):
    print("TM(1,5): INVALID_PARAMETER_ID")
    sys.exit(1)

else:
    # ACK_START check
    if tc["ack_start"]:
        print("TM(1,3): ACK_START for TC(20,129)")

    # Simulate correct parameter response
    parameter_values = {
        42: 3.14,
        # Add more parameter_id: value pairs here as needed
    }
    if tc["parameter_id"] in parameter_values:
        value = parameter_values[tc["parameter_id"]]
        print(f"TM(20,2): parameter_id={tc['parameter_id']}, value={value}")
    else:
        print("TM(1,8): DEVICE_PARAMETER_REPORT_FAILURE")
        sys.exit(1)


    
def simulate_telecommand(logical_device_id, parameter_id, ack_start):
    telemetry_log = []

    if not (0x03 <= logical_device_id <= 0x3F):
        telemetry_log.append("TM(1,4): INVALID_LOGICAL_DEVICE_ID")
        return telemetry_log

    if not (1 <= parameter_id <= 157):
        telemetry_log.append("TM(1,5): INVALID_PARAMETER_ID")
        return telemetry_log

    if ack_start:
        telemetry_log.append("TM(1,3): ACK_START for TC(20,129)")

    parameter_values = {
        42: 3.14,
        # Add more parameter_id: value pairs here as needed
    }
    if parameter_id in parameter_values:
        value = parameter_values[parameter_id]
        telemetry_log.append(f"TM(20,2): parameter_id={parameter_id}, value={value}")
    else:
        telemetry_log.append("TM(1,8): DEVICE_PARAMETER_REPORT_FAILURE")

    return telemetry_log

# Test cases 
log = simulate_telecommand(0x05, 42, True)
assert "TM(1,3): ACK_START for TC(20,129)" in log
assert "TM(20,2): parameter_id=42, value=3.14" in log
assert all("TM(1,4)" not in line for line in log)
print("Test 1 passed successfully.")

# Test: invalid logical device ID
log = simulate_telecommand(0x02, 42, True)
assert "TM(1,4): INVALID_LOGICAL_DEVICE_ID" in log
print("Test 2 passed successfully.")

# Test: invalid parameter ID
log = simulate_telecommand(0x05, 999, True)
assert "TM(1,5): INVALID_PARAMETER_ID" in log
print("Test 3 passed successfully.")

# Test: valid IDs but unknown parameter
log = simulate_telecommand(0x05, 55, True)
assert "TM(1,8): DEVICE_PARAMETER_REPORT_FAILURE" in log
print("Test 4 passed successfully.")

